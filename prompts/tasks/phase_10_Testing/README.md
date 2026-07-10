# Phase 10 — Comprehensive Testing

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-100 | Backfill backend unit tests (all validators) | P0 | 3h | All previous phases |
| PPP-101 | Backfill integration tests (all modules) | P0 | 3h | PPP-100 |
| PPP-102 | Frontend tests with Vitest + RTL + MSW | P0 | 3h | PPP-100 |
| PPP-103 | Document test run instructions, configure coverage | P1 | 1.5h | PPP-100, PPP-101, PPP-102 |

## Phase Goal

Backfill comprehensive test suite across the entire system. Unit tests for all validators, integration tests with WebApplicationFactory per module, frontend component/hook/page tests with Vitest + MSW. Configure coverage thresholds (70%+ Application layer). Document how to run tests.

## Exit Criteria

- ~15-20 validator unit tests across all modules
- ~15-20 integration tests covering auth, tasks, projects, notes, calendar, notifications
- ~15-20 frontend tests (forms, hooks, pages) with MSW API mocking
- Coverage configured with 70% threshold on Application layer
- README updated with test run instructions
- All existing tests still passing — zero regressions


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
