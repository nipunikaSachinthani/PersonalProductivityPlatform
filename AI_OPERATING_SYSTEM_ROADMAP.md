# Personal Productivity Platform — AI Operating System Roadmap

**Document class:** Executive sequencing & opportunity map
**Audience:** Lead developer, future contributors
**Status:** Generated 2026-07-03 from `productivity_platform_roadmap_2001c371.plan.md`
**Companions:** [ARCHITECTURE_ANALYSIS.md](ARCHITECTURE_ANALYSIS.md) · [ENGINEERING_MATURITY.md](ENGINEERING_MATURITY.md)

> This is the sequencing document. It says **what to do, in what order, why, and by when.**

---

## TL;DR

The Personal Productivity Platform is a greenfield learning project — zero code, zero CI, zero infrastructure. The roadmap spans 12 phases from an empty repo to a deployed, monitored system on Azure. The core technical challenge is balancing **learning velocity** (each phase teaches specific engineering concepts) with **production discipline** (testing, CI/CD, and observability built in from the start).

---

## Maturity Assessment — Current and Target

| Capability | Current | 90-day target | 12-month target |
|---|---|---|---|
| Architecture & design patterns | L0 | L3 | L4 |
| Source control hygiene | L0 | L3 | L4 |
| CI/CD | L0 | L3 | L4 |
| Test coverage | L0 | L3 | L4 |
| Static analysis / linting | L0 | L3 | L4 |
| Secret management | L0 | L2 | L3 |
| Observability | L0 | L2 | L3 |
| API contracts | L0 | L2 | L3 |
| Database migrations | L0 | L3 | L4 |
| Documentation | L0 | L2 | L3 |
| Cloud deployment | L0 | L2 | L3 |
| Event-driven patterns | L0 | L1 | L2 |

---

## ROI-Ranked Improvements (Next 90 Days)

### Tier 0 — Do This Week

| # | Action | Effort | Unlocks |
|---|---|---|---|
| 0.1 | Initialize Git repo with `.gitignore`, EditorConfig, `.editorconfig` | 15min | All work |
| 0.2 | Scaffold .NET Clean Architecture solution + React Vite app | 2h | Phase 01 foundation |
| 0.3 | Configure ESLint, Prettier, and commit hooks | 1h | Code quality gates |

### Tier 1 — Phase 01–03 (Weeks 1–3)

| # | Action | Effort | Concepts covered |
|---|---|---|---|
| 1.1 | Health check E2E: .NET → React via TanStack Query | 4h | DI, middleware, API contracts |
| 1.2 | Auth: JWT, refresh tokens, RBAC, shadcn auth pages | 8h | Security, hashing, middleware |
| 1.3 | Task CRUD: MediatR, pagination, filtering, validation | 8h | CQRS, EF Core, React Hook Form |
| 1.4 | Light tests per phase: 2–5 tests each | 2h/phase | TDD basics, mocking |

### Tier 2 — Phase 04–09 (Weeks 4–9)

| # | Action | Effort | Concepts covered |
|---|---|---|---|
| 2.1 | Projects + members + task assignment with resource auth | 8h | Many-to-many, authorization |
| 2.2 | Rich text notes with categories and FTS | 8h | Indexing, sanitization |
| 2.3 | Calendar view with FullCalendar + date queries | 8h | Timezones, range queries |
| 2.4 | Notification center with domain events + Hangfire | 8h | Event-driven, background jobs |
| 2.5 | Analytics dashboard with Recharts + aggregations | 8h | Reporting queries, caching |
| 2.6 | Azure Blob file attachments with Azurite | 8h | Cloud storage, secure uploads |

### Tier 3 — Phase 10–12 (Weeks 10–12)

| # | Action | Effort | Concepts covered |
|---|---|---|---|
| 3.1 | Comprehensive test suite (unit/integration/component) | 8h | Test pyramid, fixtures, MSW |
| 3.2 | GitHub Actions CI/CD pipeline → Azure deployment | 8h | DevOps, environments, secrets |
| 3.3 | Application Insights + Serilog observability | 4h | Structured logging, tracing |
| 3.4 | Optional: Notification Service extraction (microservices) | 8h | Service boundaries, message bus |

---

## Critical Gaps to Address

1. **No CI/CD.** Every check is manual. Fix by Phase 11 with GitHub Actions.
2. **No tests.** Greenfield means zero coverage. Fix incrementally — 2–5 tests per phase, comprehensive suite in Phase 10.
3. **No deployment.** Everything runs locally. Fix by Phase 11 with Azure App Service + Azure SQL.
4. **No monitoring.** No structured logging, no tracing, no alerts. Fix by Phase 12 with Serilog + Application Insights.
5. **Single developer.** Bus factor = 1 by design (learning project). Document decisions thoroughly so the codebase remains understandable.

---

## Missing Workflows & Automation

| Missing Piece | Why Deferred | Phase |
|---|---|---|
| GitHub Actions CI/CD | Deliberate: build product first | 11 |
| Comprehensive tests | Deliberate: 2–5 per phase, full suite at Phase 10 | 10 |
| Pre-commit hooks (Husky) | Phase 01 scaffolding | 01 |
| EF Core migration validation | Part of each DB phase | 03+ |
| OpenAPI → TypeScript client generation | Optional: Phase 03 | 03 |
| Rate limiting on auth | Phase 02 | 02 |
| CORS configuration | Phase 01 | 01 |

---

## Operational Bottlenecks

1. **Single developer.** All work from one contributor. This is a learning project — mitigate by documenting every architectural decision.
2. **No staging environment.** All testing is local or production. Introduce dev/staging in Phase 11.
3. **No backup strategy.** Phase 11+ to address Azure SQL automated backups.

---

## AI Leverage Opportunities — Sequenced

### Near (Phases 01–04)
- Scaffold Clean Architecture solution from template
- Generate EF Core entity configurations from domain models
- Auto-generate FluentValidation validators from DTOs
- Draft ADR-style decision records for key choices

### Mid (Phases 05–09)
- Generate aggregation queries from dashboard spec
- Draft event handler boilerplate from event definitions
- Generate test fixtures and seed data builders

### Far (Phases 10–12)
- Auto-generate CI/CD workflow files
- Propose refactoring opportunities from code analysis
- Generate Application Insights query templates

---

## Cost & Resource Notes

- **Azure costs:** App Service (B1), Azure SQL (Basic), Blob Storage (~$50–80/month combined)
- **Learning investment:** ~8–12 hours/week over 12 weeks
- **Local development:** SQL Server LocalDB, Azurite, all free

---

## What This Roadmap Does Not Include

- Mobile native apps (out of scope)
- Real-time collaboration (WebSockets — stretch goal only)
- Third-party integrations (Slack, Google Calendar)
- Multi-tenancy / SaaS billing
- Email delivery infrastructure (stub in dev)

---

## Reading Map for This Project

| Role | Read in Order |
|---|---|
| Developer | This roadmap → Architecture Analysis → Engineering Maturity → Phase docs |
| Reviewer | SECURITY.md (to be created) → Architecture Analysis → Phase-specific spec |
| AI Tool | AGENTS.md (to be created) → This roadmap → Phase prompt files |

---

## Closing Principle

> "Build the product incrementally; let the architecture emerge from real needs, not speculation."
> — operating philosophy for this 12-week learning journey

The platform starts greenfield. Each phase adds a complete, working slice. By Phase 12, you have a production-quality system — and 12 weeks of deliberate practice across the full stack.
