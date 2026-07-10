# Phase 05 — Notes Module

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-050 | Create Notes + Categories schema | P0 | 1.5h | PPP-030 |
| PPP-051 | Implement CreateNote with content sanitization | P0 | 2h | PPP-050 |
| PPP-052 | Implement GetNotes list with search + filtering | P0 | 2h | PPP-051 |
| PPP-053 | Implement GetNoteById + Update + Delete | P0 | 1.5h | PPP-051 |
| PPP-054 | Implement Category CRUD endpoints | P1 | 1.5h | PPP-050 |
| PPP-055 | Integrate TipTap rich text editor | P0 | 2.5h | PPP-051 |
| PPP-056 | Build Notes list UI with search bar + category filters | P0 | 2h | PPP-052, PPP-055 |
| PPP-057 | Write light tests for notes | P1 | 1.5h | PPP-051, PPP-052 |

## Phase Goal

Rich-text notes module with TipTap editor, personal categories, full-text search (LIKE-based initially), content sanitization for XSS prevention, and optional project linking. Captures knowledge alongside tasks.

## Exit Criteria

- Notes CRUD with content sanitization working
- Search returning matching notes by title and content
- Category CRUD with per-user uniqueness
- TipTap editor with toolbar (bold, italic, headings, lists, links)
- Notes list UI with debounced search and category filter chips
- 2 unit tests passing (search handler, XSS sanitization)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
