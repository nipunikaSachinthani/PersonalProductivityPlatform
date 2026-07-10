# Phase 03 — Task Management

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-030 | Create Tasks schema + migration | P0 | 1.5h | PPP-004, PPP-010 |
| PPP-031 | Implement CreateTask command + endpoint | P0 | 2h | PPP-030 |
| PPP-032 | Implement GetTasks list query (pagination, filtering, sorting) | P0 | 2h | PPP-031 |
| PPP-033 | Implement GetTaskById + UpdateTask | P0 | 1.5h | PPP-031 |
| PPP-034 | Implement DeleteTask, Complete, Reopen | P0 | 1.5h | PPP-031 |
| PPP-035 | Build Task List UI with filters and pagination | P0 | 2.5h | PPP-019, PPP-032 |
| PPP-036 | Build Create/Edit Task form (dialog + validation) | P0 | 2h | PPP-031, PPP-035 |
| PPP-037 | Build Task Detail view with actions | P1 | 1.5h | PPP-033, PPP-035 |
| PPP-038 | Write light tests for tasks | P1 | 2h | PPP-031, PPP-032, PPP-034 |

## Phase Goal

Full CRUD task management with priority levels, status workflow (Todo → InProgress → Done), due dates, paginated/filtered/sorted task list, and ownership authorization. Users can only access their own tasks.

## Exit Criteria

- All task CRUD endpoints working with validation
- Pagination, filtering, and sorting functional
- Complete/reopen state transitions enforced
- Task list UI with all states (loading, empty, error, data)
- Task form with Zod validation
- 4 light tests passing (validator, handler, integration, component)
