# Phase 06 — Calendar

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-060 | Create CalendarEvents schema | P0 | 1.5h | PPP-030 |
| PPP-061 | Implement GetCalendar date-range endpoint | P0 | 2h | PPP-060 |
| PPP-062 | Implement CalendarEvent CRUD | P0 | 1.5h | PPP-060 |
| PPP-063 | Integrate FullCalendar (month/week/day views) | P0 | 2.5h | PPP-061 |
| PPP-064 | Implement drag-to-reschedule for task due dates | P0 | 1.5h | PPP-063 |
| PPP-065 | Write light tests for calendar | P1 | 1.5h | PPP-061, PPP-062 |

## Phase Goal

Visual calendar showing task due dates and standalone events, with drag-to-reschedule for intuitive date management. FullCalendar integration with month/week/day views, color-coded by priority/type, and UTC timezone discipline.

## Exit Criteria

- Calendar endpoint returning tasks + events within date range
- FullCalendar with three views working
- Drag-to-reschedule updating task due dates via API
- Calendar event CRUD functional
- 2 tests passing (date-range query unit + integration)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
