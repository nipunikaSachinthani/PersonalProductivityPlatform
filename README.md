# Personal Productivity Platform

A full-stack personal productivity application combining task management, project collaboration, rich-text notes, calendar scheduling, notifications, and analytics.

**Stack:** .NET 8 Clean Architecture API + React 18 SPA with Tailwind/shadcn/ui + SQL Server

---

## Quick Start

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

### Backend (API)

```bash
cd backend/src/ProductivityPlatform.Api
dotnet run
```

Open https://localhost:5001/swagger to explore the API.

### Frontend

```bash
cd frontend
npm install
npm run dev
```

Open http://localhost:5173 in your browser.

### Health Check

```bash
curl http://localhost:5000/api/v1/health
```

---

## Project Structure

```
backend/
  src/
    ProductivityPlatform.Api/           # Controllers, middleware, DI
    ProductivityPlatform.Application/   # CQRS handlers, DTOs, validators
    ProductivityPlatform.Domain/        # Entities, enums, domain events
    ProductivityPlatform.Infrastructure/ # EF Core, repositories, identity
  tests/

frontend/
  src/
    pages/
    components/
    features/
    services/
    hooks/
    types/

prompts/
  tasks/                                # Phase-by-phase task definitions
```

---

## Documentation

- [Architecture Analysis](ARCHITECTURE_ANALYSIS.md)
- [Engineering Principles](PRINCIPLES.md)
- [Engineering Maturity](ENGINEERING_MATURITY.md)

## Phases

| Phase | Module |
|---|---|
| 01 | Project Setup & Foundation |
| 02 | Authentication & Authorization |
| 03 | Task Management |
| 04 | Projects |
| 05 | Notes |
| 06 | Calendar |
| 07 | Notifications |
| 08 | Dashboard & Analytics |
| 09 | File Uploads |
| 10 | Testing & Quality |
| 11 | DevOps & Deployment |
| 12 | Monitoring & Observability |
