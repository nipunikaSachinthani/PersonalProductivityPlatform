# Personal Productivity Platform — Architecture Analysis

**Document class:** Repository-derived architectural baseline
**Audience:** Developer, future contributors
**Status:** Generated 2026-07-03 from `productivity_platform_roadmap_2001c371.plan.md`
**Authority:** Descriptive (what *will be* built), not prescriptive
**Refresh trigger:** After each phase completion

> This document records what the platform **will look like** at full build-out.
> It serves as the architecture reference during development.

---

## 1. Project Purpose

A full-stack personal productivity web application combining task management, project collaboration, rich-text notes, calendar scheduling, notifications, and analytics into a single cohesive platform. Built as a 12-phase learning project covering the complete software development lifecycle — from empty repository to deployed, monitored system on Azure.

**Core modules:** Tasks, Projects, Notes, Calendar, Notifications, Dashboard, File Attachments, Authentication & Administration.

---

## 2. Architecture Style

**Style:** Modular monolith (Phases 01–11), with optional microservices decomposition in Phase 12.

**Frontend:** Single-page React application communicating with the backend via REST API.

**Backend:** .NET 8 Web API following Clean Architecture with CQRS via MediatR.

**Why modular monolith first:**
1. The domain is not yet fully understood — boundaries will emerge through building.
2. A monolith is simpler to develop, test, and deploy as a learning project.
3. Phase 12 provides a deliberate decomposition exercise once the domain is stable.

**Communication patterns:**
- **Sync HTTP/JSON** between React SPA and .NET API.
- **In-process domain events** via MediatR `INotificationHandler<T>` for cross-module side effects (e.g., task assigned → notification created).
- **Background jobs** via Hangfire for scheduled work (due-date reminders).
- **Azure Service Bus / RabbitMQ** (Phase 12 optional) for inter-service messaging.

---

## 3. Domain Boundaries

Each module owns its domain logic. Cross-module communication goes through MediatR events (in-process) or the API surface (out-of-process).

| Module | Owns | Talks To |
|---|---|---|
| Auth | Users, Roles, RefreshTokens, Permissions | All modules (authorization) |
| Tasks | Task entities, status, priority | Projects, Calendar, Notifications |
| Projects | Project entities, membership, roles | Tasks, Notes |
| Notes | Note entities, categories, rich text | Projects |
| Calendar | Calendar events, task-due-date views | Tasks |
| Notifications | Notification entities, read state | Tasks (events), Projects (events) |
| Dashboard | Aggregation read models | Tasks, Projects |
| Attachments | File metadata, blob references | Tasks, Azure Blob Storage |

---

## 4. Technology Stack

### Database Tier
- **SQL Server** (LocalDB for development, Azure SQL for production)
- **EF Core** for data access, migrations, and change tracking
- **EF Core Migrations** for versioned schema changes (never manual DDL in production)
- **Full-Text Search** on Notes content (Phase 05)

### Backend Tier — .NET 8 Web API
- **Clean Architecture:** Domain → Application → Infrastructure → API
- **CQRS with MediatR:** Commands, queries, and notification handlers
- **FluentValidation** for input validation at the API boundary
- **Serilog** for structured logging
- **ASP.NET Core Identity** with custom JWT implementation
- **Hangfire** for background job processing (Phase 07)
- **Result pattern:** `Result<T>` for expected failures; global exception middleware for unexpected errors
- **ApiResponse envelope:** `{ data, errors, meta }` for consistent API responses

### Frontend Tier — React SPA
- **React 18 + TypeScript** with strict mode
- **Vite** for build tooling
- **Tailwind CSS + shadcn/ui** for design system
- **TanStack Query** for server state management
- **React Hook Form + Zod** for form validation
- **React Router** for client-side routing
- **FullCalendar** for calendar views (Phase 06)
- **TipTap or Lexical** for rich-text editing (Phase 05)
- **Recharts** for dashboard charts (Phase 08)
- **MSW (Mock Service Worker)** for API mocking in tests (Phase 10)

### Infrastructure Tier (Phase 11+)
- **Azure App Service** for hosting .NET API and React SPA
- **Azure SQL** for production database
- **Azure Blob Storage** for file attachments (Azurite emulator locally)
- **Application Insights** for monitoring (Phase 12)
- **GitHub Actions** for CI/CD pipelines

---

## 5. Naming & Coding Conventions

| Surface | Convention |
|---|---|
| .NET projects | PascalCase: `ProductivityPlatform.Api`, `ProductivityPlatform.Domain` |
| .NET classes | PascalCase: `TaskController`, `CreateTaskCommand` |
| .NET methods | PascalCase: `GetTasksAsync`, `Handle` |
| .NET interfaces | PascalCase with I prefix: `ITaskRepository`, `IUnitOfWork` |
| SQL tables | PascalCase, plural: `Tasks`, `Projects`, `ProjectMembers` |
| SQL columns | PascalCase: `Id`, `CreatedByUserId`, `DueDate` |
| Primary keys | `int` auto-increment or `Guid` per entity |
| Timestamps | `DateTime.UtcNow`; `CreatedAt`, `UpdatedAt` suffixes |
| React components | PascalCase `.tsx`, one component per file |
| React hooks | camelCase prefixed with `use`: `useAuth`, `useTasks` |
| TypeScript types | PascalCase interfaces: `Task`, `Project`, `User` |
| API routes | `api/v1/[plural-resource]`: `/api/v1/tasks` |
| Git commits | Conventional commits: `feat(tasks): add CRUD endpoints` |

---

## 6. Backend Folder Structure (Phase 01)

```
backend/
  src/
    ProductivityPlatform.Api/           # Controllers, middleware, DI, Program.cs
      Controllers/
      Middleware/
      Program.cs
    ProductivityPlatform.Application/   # Commands, queries, handlers, DTOs, validators
      Tasks/
        Commands/
        Queries/
      Projects/
      Common/
    ProductivityPlatform.Domain/        # Entities, enums, domain events, interfaces
      Entities/
      Enums/
      Events/
      Interfaces/
    ProductivityPlatform.Infrastructure/ # EF Core, repositories, identity, blob, email
      Persistence/
      Identity/
      Storage/
  tests/
    ProductivityPlatform.UnitTests/
    ProductivityPlatform.IntegrationTests/
```

---

## 7. Frontend Folder Structure (Phase 01)

```
frontend/
  src/
    pages/          # Route-level screens (LoginPage, DashboardPage, TasksPage)
    components/     # Reusable UI (shadcn in components/ui/)
      ui/           # shadcn/ui primitives
    features/       # Feature modules grouped by domain
      auth/         # LoginForm, RegisterForm, auth store
      tasks/        # TaskList, TaskForm, TaskDetail
      projects/     # ProjectCard, ProjectSidebar
    services/       # API client modules (authApi, tasksApi)
    hooks/          # Custom hooks (useAuth, useTasks, useDebounce)
    layouts/        # AppShell, AuthLayout
    routes/         # Route definitions + auth guards
    types/          # Shared TypeScript interfaces
    lib/            # Utils, queryClient, cn() helper
```

---

## 8. API Design Standards

- **REST + JSON** with versioning: `/api/v1/`
- **Pagination:** `?page=1&pageSize=20` on list endpoints
- **Filtering:** `?status=Todo&priority=High` query params
- **Sorting:** `?sortBy=dueDate&sortOrder=asc`
- **Error envelope:** `{ "errors": [{ "code": "...", "message": "..." }] }`
- **Success envelope:** `{ "data": {...}, "meta": { "page": 1, "pageSize": 20, "totalCount": 150 } }`
- **JWT Bearer** authentication on all non-auth endpoints
- **CORS** explicitly configured for the frontend origin
- **Rate limiting** on auth endpoints (Phase 02)

---

## 9. Database Entity Relationships (Full Build-Out)

```
Users 1──* RefreshTokens
Users 1──* Tasks (CreatedBy)
Users *──* Projects (via ProjectMembers)
Users 1──* Notes
Users 1──* Notifications
Users 1──* Attachments (UploadedBy)

Projects 1──* ProjectMembers
Projects 1──* Tasks
Projects 1──* Notes (optional FK)

Tasks 1──* Attachments
Tasks 1──0..1 CalendarEvents (via due date)

Notes *──* Categories (via NoteCategories)
```

---

## 10. Cross-Cutting Patterns

| Pattern | Implementation |
|---|---|
| **Validation** | FluentValidation on all command/query DTOs; Zod on React forms |
| **Authorization** | ASP.NET Core `[Authorize]` policies; resource-level checks via custom handlers |
| **Logging** | Serilog structured logging; correlation IDs propagated through middleware |
| **Error handling** | Global exception middleware; `Result<T>` pattern for domain errors |
| **Caching** | `IMemoryCache` for dashboard aggregations (Phase 08) |
| **Background jobs** | Hangfire for due-date reminders (Phase 07) |
| **API client** | Axios/fetch wrapper with JWT interceptor and 401-refresh logic |
| **Migrations** | EF Core migrations checked into source control |

---

## 11. Deployment Topology (Phase 11 Target)

```
                          Azure
  ┌─────────────────────────────────────────┐
  │  App Service (API)                       │
  │   └─ .NET 8 Web API                     │
  │       └─ Serilog → App Insights         │
  │                                         │
  │  App Service (Web)                       │
  │   └─ React SPA (static files served)    │
  │                                         │
  │  Azure SQL                               │
  │   └─ ProductivityPlatform database      │
  │                                         │
  │  Azure Blob Storage                      │
  │   └─ task-attachments container         │
  │                                         │
  │  Application Insights                    │
  │   └─ telemetry + dashboards             │
  └─────────────────────────────────────────┘

GitHub Actions:
  Push → Build → Test → Deploy to Azure
```

---

## 12. Scope Boundaries

**In scope:**
- React SPA with Tailwind + shadcn/ui
- .NET 8 Clean Architecture API
- SQL Server with EF Core migrations
- JWT authentication with refresh tokens
- In-app notifications (not email/SMS in core phases)
- Azure deployment with CI/CD

**Out of scope:**
- Mobile native apps
- Real-time collaboration (WebSockets — stretch goal)
- Third-party integrations (Slack, Google Calendar)
- Multi-tenancy / SaaS billing
- Email delivery (stub only in Phase 02)

---

## 13. What This Document Is *Not*

- It is **not** a replacement for the phased roadmap — that's `productivity_platform_roadmap_2001c371.plan.md`.
- It is **not** a risk register — those are tracked per-phase in the review checklists.
- It is **not** a deployment runbook — that gets created in Phase 11.

Use it to understand the architecture at any point in the build-out.
