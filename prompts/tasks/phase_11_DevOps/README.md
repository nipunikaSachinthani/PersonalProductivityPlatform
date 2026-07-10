# Phase 11 — DevOps & CI/CD

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-110 | Create GitHub Actions CI build workflow | P0 | 2h | All previous phases |
| PPP-111 | Add lint and format checks to CI | P0 | 1.5h | PPP-110 |
| PPP-112 | Add tests to CI + create CD deploy to Azure workflow | P0 | 2h | PPP-110, PPP-100, PPP-101 |

## Phase Goal

Automated CI/CD pipeline. On every push/PR: build .NET + React, run linters, run tests. On merge to main: deploy API to Azure App Service, React to Azure Static Web Apps, run EF Core migrations against Azure SQL. GitHub Secrets for all sensitive values.

## Exit Criteria

- CI workflow runs on push/PR: builds pass, lint checks pass, tests pass
- CD workflow deploys on merge to main: API deployed, frontend deployed, migrations applied
- GitHub Secrets configured for connection strings and JWT key
- Dev environment functional on Azure
- Deployment health check passes


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
