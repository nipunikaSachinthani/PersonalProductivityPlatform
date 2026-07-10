# QA Test Automation Spec — Personal Productivity Platform (QA v0.1)

**Audience:** AI coding agent (build + run)
**Status:** Ready to build after Phase 03 (Tasks module) is complete
**Tracker:** Create a GitHub issue for this spec when the repo is initialized
**Git Workflow:** All branches, commits, and PRs for this spec MUST follow `GIT_WORKFLOW.md`

This is a **buildable, runnable spec** for an automated QA test suite that exercises
the deployed Personal Productivity Platform end to end — auth, CRUD, authorization,
and health checks — and exits non-zero on any failure so it can gate the release.

---

## 1. Environment Under Test

| Thing | Value |
|---|---|
| API host | `localhost` initially; Azure App Service URL after Phase 11 |
| API URL | `http://localhost:5000/api/v1` (or configured via `API_BASE_URL` env) |
| Database | SQL Server LocalDB (dev) / Azure SQL (prod) |
| Swagger | `http://localhost:5000/swagger` |
| Test users | Created programmatically via auth endpoints |
| Migrations expected | Varies by phase; verify via `/api/v1/health` database check |

Get a token:
```bash
curl -s "http://localhost:5000/api/v1/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"TestPass!123"}' \
  | python3 -c 'import sys,json;print(json.load(sys.stdin)["data"]["accessToken"])'
```

---

## 2. KNOWN-FAILING — Track These as XFAIL

Live-probed at build time. Encode as assertions; some may be RED until fixes land.

1. **🔴 BLOCKER — Auth endpoint returns 401 after deploy.**
   JWT key mismatch between build environments. Root cause: `appsettings.Production.json` or Azure Key Vault misconfiguration.
   **Acceptance:** `POST /api/v1/auth/login` with valid credentials returns 200 with token.
   → Investigate environment-specific key configuration. Block all authed tests until resolved.

2. **🟠 Authorization tests may fail if RBAC not fully implemented.**
   Phase 02 introduces RBAC. Tests for resource-level authorization (Phase 04+) should be tagged
   `xfail` until the relevant phase is complete.

3. **🟠 Database connectivity in CI.**
   Integration tests require SQL Server. Use Testcontainers or LocalDB in CI.
   **Acceptance:** `/api/v1/health` returns database status "Healthy".

---

## 3. Coverage Matrix (What to Test)

### 3.1 Infrastructure / Liveness
- [ ] `/api/v1/health` returns 200 with `{ "status": "Healthy", "database": "Healthy" }`.
- [ ] Swagger UI loads at `/swagger` and shows all registered endpoints.
- [ ] API returns CORS headers for the configured frontend origin.

### 3.2 Auth (Identity Path)
- [ ] `POST /api/v1/auth/register` creates user; returns 201 with user DTO (no password in response).
- [ ] `POST /api/v1/auth/login` with valid credentials returns 200 with `accessToken` and `refreshToken`.
- [ ] `POST /api/v1/auth/login` with invalid credentials returns 401.
- [ ] `POST /api/v1/auth/refresh` with valid refresh token returns new token pair.
- [ ] `POST /api/v1/auth/refresh` with expired/invalid refresh token returns 401.
- [ ] Unauthenticated requests to protected endpoints return 401.
- [ ] Malformed JWT returns 401.
- [ ] Rate limiting on auth endpoints (if implemented in Phase 02).

### 3.3 Task CRUD (Phase 03)
Smoke each operation with a valid token:

- [ ] `GET /api/v1/tasks` returns 200 with paginated array (`{ data: [...], meta: { page, pageSize, totalCount } }`).
- [ ] `GET /api/v1/tasks?page=1&pageSize=20` returns correct page size.
- [ ] `GET /api/v1/tasks?status=Todo&priority=High` returns filtered results.
- [ ] `POST /api/v1/tasks` with valid body returns 201 with server-generated ID.
- [ ] `POST /api/v1/tasks` with invalid body returns 400 with validation errors.
- [ ] `GET /api/v1/tasks/{id}` returns 200 for own task.
- [ ] `GET /api/v1/tasks/{id}` returns 404 for non-existent task.
- [ ] `GET /api/v1/tasks/{id}` returns 403 for another user's task (authorization check).
- [ ] `PATCH /api/v1/tasks/{id}` updates title, status, priority, or due date; returns 200.
- [ ] `PATCH /api/v1/tasks/{id}/complete` marks task as Done; sets CompletedAt.
- [ ] `PATCH /api/v1/tasks/{id}/reopen` changes status from Done back to Todo.
- [ ] `DELETE /api/v1/tasks/{id}` soft-deletes or hard-deletes per implementation; verify task is no longer in list.
- [ ] Tasks created by User A are NOT visible in User B's list (authorization).

### 3.4 Project CRUD (Phase 04)
- [ ] `POST /api/v1/projects` creates project; assigning user as Owner.
- [ ] `GET /api/v1/projects` returns user's projects.
- [ ] `POST /api/v1/projects/{id}/members` adds member.
- [ ] Non-member cannot view project tasks.
- [ ] Member can view project tasks; Viewer cannot edit.
- [ ] `GET /api/v1/projects/{id}/tasks` returns task list scoped to project.

### 3.5 Notes CRUD (Phase 05)
- [ ] `POST /api/v1/notes` with rich text content returns 201.
- [ ] `GET /api/v1/notes?search=term` returns matching notes.
- [ ] XSS content is sanitized on write.

### 3.6 Calendar (Phase 06)
- [ ] `GET /api/v1/calendar?start=YYYY-MM-DD&end=YYYY-MM-DD` returns tasks in range.
- [ ] `PATCH /api/v1/tasks/{id}` with new due date reflects in calendar.

### 3.7 Notifications (Phase 07)
- [ ] `GET /api/v1/notifications` returns user's notifications.
- [ ] `PATCH /api/v1/notifications/{id}/read` marks as read.
- [ ] Task assignment creates a notification for the assignee.

### 3.8 Dashboard (Phase 08)
- [ ] `GET /api/v1/dashboard/summary` returns task counts by status.
- [ ] `GET /api/v1/dashboard/charts?range=30d` returns trend data.
- [ ] Dashboard data is user-scoped.

### 3.9 File Attachments (Phase 09)
- [ ] `POST /api/v1/tasks/{id}/attachments` uploads file; returns 201.
- [ ] `GET /api/v1/attachments/{id}` returns file or download URL.
- [ ] File size validation rejects oversized files.
- [ ] Unauthorized user cannot upload to another user's task.

---

## 4. Deliverables (What to Build)

1. **`tests/qa-e2e.py`** — Python 3.11, stdlib + `requests` only.
   - Reads target from env (`API_BASE_URL`, `TEST_USER_EMAIL`, `TEST_USER_PASSWORD`) with defaults.
   - Implements §3.1–§3.5. Additional modules (§3.6–§3.9) added per phase.
   - Structured output: per-check `PASS/FAIL/XFAIL/SKIP`, summary table, machine-readable `qa-e2e-report.json`.
   - **Exit codes:** `0` = all required pass (XFAIL/SKIP allowed); `1` = required check failed; `2` = environment unreachable.
   - Known issues from §2 tagged as `XFAIL` with tracker refs.
2. **`tests/qa-e2e.md`** — how to run, env vars, exit codes.
3. **Run it** against the local or deployed environment and attach the report.

---

## 5. Acceptance for This Task

- [ ] `tests/qa-e2e.py` exists and runs against the target environment.
- [ ] All §3 checks implemented; §2 known failures encoded as XFAIL.
- [ ] First run executed; report posted with current pass/fail snapshot.
- [ ] Conventional commit: `test(qa): add end-to-end QA automation suite` (per GIT_WORKFLOW.md §5)
- [ ] Branch named per GIT_WORKFLOW.md §3: e.g., `feature/qa-automation-suite-PPP-100`

---

## 6. Guardrails (Do Not Violate)

- **No hardcoded test credentials.** Use environment variables.
- **Test with synthetic data only.** Prefix test entities with `QATEST-` for cleanable runs.
- **Read-only against production data.** Never mutate real user data.
- **Clean up after tests.** Delete created test data or use a dedicated test database.
- **Exit non-zero on failure.** A failing test must fail the CI pipeline.
- **No real secrets in the test file.** API keys, JWT secrets, and connection strings go through env vars.
