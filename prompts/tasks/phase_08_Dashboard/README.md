# Phase 08 — Analytics Dashboard

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-080 | Implement Dashboard summary aggregation endpoint | P0 | 2.5h | PPP-032 |
| PPP-081 | Implement Dashboard charts endpoint (daily completions) | P0 | 2h | PPP-080 |
| PPP-082 | Build Dashboard page with stat cards | P0 | 2h | PPP-080 |
| PPP-083 | Integrate Recharts bar and line charts | P0 | 2h | PPP-081, PPP-082 |
| PPP-084 | Write light test for dashboard | P1 | 1.5h | PPP-080, PPP-081 |

## Phase Goal

Productivity analytics dashboard showing completed tasks this week, overdue count, status/priority breakdowns, completion rate, and daily completion trend chart with configurable date range. Cached with IMemoryCache for performance.

## Exit Criteria

- Summary endpoint returning all metrics with correct aggregation
- Charts endpoint returning daily completion counts (zero-filled)
- Stat cards with animated numbers on dashboard page
- Recharts bar chart (status breakdown) and line chart (completions over time)
- Date range selector (7d/30d/90d) driving chart data
- 1 integration test passing (seeded data → correct counts)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
