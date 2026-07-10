# Phase 01 — Project Setup

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-001 | Initialize Git repo and project folder structure | P0 | 1h | None |
| PPP-002 | Scaffold .NET Clean Architecture solution | P0 | 2h | PPP-001 |
| PPP-003 | Scaffold React + Vite + Tailwind + shadcn UI | P0 | 2h | PPP-001 |
| PPP-004 | Configure EF Core with LocalDB and initial migration | P0 | 2h | PPP-002 |
| PPP-005 | Configure Swagger, Serilog, and appsettings | P0 | 1.5h | PPP-002 |
| PPP-006 | Configure ESLint, Prettier, EditorConfig | P0 | 1.5h | PPP-003 |
| PPP-007 | Create health check endpoint and landing page E2E | P0 | 2h | PPP-002, PPP-003, PPP-004, PPP-005 |
| PPP-008 | Write light integration test for health endpoint | P1 | 1.5h | PPP-007 |

## Phase Goal

Professional repo skeleton, tooling, and "hello world" end-to-end. Establishes the foundation every subsequent phase builds on: Git hygiene, Clean Architecture structure, frontend tooling, database connectivity, API documentation, code quality enforcement, and a working vertical slice.

## Exit Criteria

- `dotnet run` + `npm run dev` both work
- Swagger loads at `/swagger`
- One API call from React succeeds (health check)
- All linting and formatting gates pass
- Integration test passes (`dotnet test`)
