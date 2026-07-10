# Phase 07 — Notifications

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-070 | Create Notifications schema + domain events | P0 | 1.5h | PPP-030 |
| PPP-071 | Publish domain events from task handlers | P0 | 2h | PPP-070, PPP-034 |
| PPP-072 | Implement MediatR NotificationHandlers | P0 | 2h | PPP-070, PPP-071 |
| PPP-073 | Implement Hangfire background job for due-date reminders | P0 | 2h | PPP-070 |
| PPP-074 | Implement notification query + mark-read endpoints | P0 | 1.5h | PPP-070 |
| PPP-075 | Build notification bell UI with dropdown | P1 | 2h | PPP-074 |
| PPP-076 | Write light tests for notifications | P1 | 1.5h | PPP-072, PPP-073 |

## Phase Goal

Event-driven in-app notification center. Task completion and assignment trigger notifications via MediatR domain events. Hangfire recurring job sends due-date reminders. Notification bell in header with unread badge and dropdown.

## Exit Criteria

- Task completion creates a notification for the owner
- Task assignment creates notifications for project members
- Hangfire hourly job scans for tasks due within 24 hours
- Notification bell shows unread count and dropdown list
- Mark as read / mark all read working
- 2 tests passing (event handler + background job)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
