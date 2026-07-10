# Phase 04 — Projects

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-040 | Create Projects + ProjectMembers schema | P0 | 2h | PPP-030 |
| PPP-041 | Implement CreateProject endpoint | P0 | 2h | PPP-040 |
| PPP-042 | Implement GetProjects + GetProjectById | P0 | 2h | PPP-041 |
| PPP-043 | Implement UpdateProject + ArchiveProject | P0 | 1.5h | PPP-041 |
| PPP-044 | Implement Add/Remove Members with authorization | P0 | 2h | PPP-041 |
| PPP-045 | Implement task-to-project assignment + project tasks | P0 | 1.5h | PPP-031, PPP-041 |
| PPP-046 | Build Project sidebar and creation dialog | P0 | 2h | PPP-042, PPP-035 |
| PPP-047 | Build Project Detail page (tasks + members) | P0 | 2h | PPP-042, PPP-044, PPP-045 |
| PPP-048 | Write light tests for projects | P1 | 2h | PPP-041, PPP-043, PPP-044 |

## Phase Goal

Project-based task organization with membership roles (Owner/Member/Viewer), resource-level authorization, task assignment, and collaborative workflows. Projects introduce many-to-many relationships and complex authorization rules.

## Exit Criteria

- Projects CRUD with auto-owner membership
- Member management with role enforcement (last-owner invariant)
- Task assignment to projects with membership-based access
- Project sidebar and detail page with role-aware UI
- 3 integration tests passing (authorization, assignment, membership)
