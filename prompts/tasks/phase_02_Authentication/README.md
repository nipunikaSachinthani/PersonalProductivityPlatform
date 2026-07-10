# Phase 02 — Authentication & Authorization

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-010 | Create Identity database schema | P0 | 2h | PPP-004 |
| PPP-011 | Implement User Registration endpoint | P0 | 2.5h | PPP-010 |
| PPP-012 | Implement User Login with JWT generation | P0 | 2.5h | PPP-011 |
| PPP-013 | Implement Refresh Token rotation and Logout | P0 | 2h | PPP-012 |
| PPP-014 | Implement Forgot/Reset Password flow | P1 | 2h | PPP-011 |
| PPP-015 | Protect APIs with JWT middleware and RBAC | P0 | 2h | PPP-012 |
| PPP-016 | Implement GET /users/me endpoint | P0 | 1h | PPP-015 |
| PPP-017 | Build Login page (shadcn form) | P0 | 2h | PPP-012, PPP-003 |
| PPP-018 | Build Registration page | P0 | 1.5h | PPP-011, PPP-017 |
| PPP-019 | Build Forgot Password page, Auth context, route guards | P1 | 2h | PPP-016, PPP-017, PPP-018 |
| PPP-020 | Write light tests for auth | P1 | 2h | PPP-011, PPP-012, PPP-015, PPP-017 |

## Phase Goal

Secure user registration, login, JWT-based sessions with refresh tokens, role-based access control, password reset flow, and fully integrated auth frontend. This phase underpins every secured endpoint in subsequent phases.

## Exit Criteria

- Registration and login working end-to-end
- JWT authentication protecting API endpoints
- Refresh token rotation implemented
- All auth frontend pages built and connected
- 4 light tests passing (password hasher, login handler, register API, login form)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
