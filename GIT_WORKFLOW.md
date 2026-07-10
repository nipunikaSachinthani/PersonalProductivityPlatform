# Git Workflow Standard

**Document Class:** Engineering Governance — Universal Git Guideline
**Audience:** All engineers (human and autonomous agents) working in organizational repositories
**Status:** Active — Mandatory
**Owner:** Office of the Principal AI Systems Architect
**Effective From:** 2026-07-10
**Binding Authority:** This document is the single source of truth for all Git operations across every repository in the organization. Where this document conflicts with any project README, local `.gitconfig`, or ad-hoc workflow, this document wins.
**Supersedes:** All prior branch naming conventions, commit guidelines, and merge policies across all projects.

---

## Table of Contents

1. [Introduction & Philosophy](#1-introduction--philosophy)
2. [Repository Structure](#2-repository-structure)
3. [Branch Naming Conventions](#3-branch-naming-conventions)
4. [Branch Lifecycle & Strategy](#4-branch-lifecycle--strategy)
5. [Commit Standards — Conventional Commits](#5-commit-standards--conventional-commits)
6. [Pull Request Standards](#6-pull-request-standards)
7. [Code Review Process](#7-code-review-process)
8. [Merge Strategies](#8-merge-strategies)
9. [Release Workflow](#9-release-workflow)
10. [CI/CD Integration](#10-cicd-integration)
11. [Git Configuration & Hygiene](#11-git-configuration--hygiene)
12. [Troubleshooting & Recovery](#12-troubleshooting--recovery)
13. [Appendix A — Quick Reference Card](#13-appendix-a--quick-reference-card)
14. [Appendix B — Workflow Decision Trees](#14-appendix-b--workflow-decision-trees)

---

## 1. Introduction & Philosophy

### 1.1 Why a Formal Git Workflow?

Git is the single source of truth for every repository. A formal Git workflow ensures:

- **Traceability:** Every change is linked to a task, an issue, and a rationale.
- **Consistency:** Branch names, commits, and PRs follow predictable patterns.
- **Automation:** CI/CD, changelog generation, and release tooling rely on structured Git metadata.
- **Collaboration:** Multiple agents and humans can work concurrently without stepping on each other.
- **Safety:** Branch protections and merge policies prevent destructive actions.

### 1.2 Core Principles

1. **Main is always deployable.** Every commit on `main` has passed all quality gates.
2. **Short-lived branches.** Branches live ≤ 3 days. Longer branches accumulate integration risk.
3. **One concern per PR.** A PR does one thing and does it well.
4. **Commits tell a story.** A well-structured commit history is documentation.
5. **Automation over ceremony.** Mechanical checks (lint, test, format) are enforced by CI, not human review.
6. **History is immutable on protected branches.** No force-push, no rewrite, no deletion.

### 1.3 Relationship to Other Documents

| Document | Relationship |
|---|---|
| `AAOS.md` (§11 — GitHub Operational Model) | Constitutional governance; this document is the operational expansion |
| `PRINCIPLES.md` | Day-to-day engineering principles; references this document |
| `TaskPrompts/GENERATE_PHASE_SPECS.md` | Task template generator; all generated tasks inherit this workflow |
| Individual `PPP-NNN.md` task prompts | Each task's deliverable section specifies branch/commit/PR per this standard |

---

## 2. Repository Structure

Every organizational repository SHALL maintain the following structure:

```
.
├── .github/
│   ├── workflows/               ← CI/CD pipeline definitions
│   ├── CODEOWNERS               ← Code ownership for review routing
│   └── PULL_REQUEST_TEMPLATE.md  ← Mandatory PR template
├── docs/                        ← Project documentation, ADRs, runbooks
├── src/ or backend/             ← Primary source code
├── tests/                       ← Test suites
├── .editorconfig                ← Cross-editor consistency
├── .gitignore                   ← Excluded files and directories
├── GIT_WORKFLOW.md              ← This document (repository-local override if needed)
└── README.md                    ← Project overview
```

---

## 3. Branch Naming Conventions

All branch names MUST follow the pattern: `<type>/<short-description>-<reference-id>`

### 3.1 Branch Types

| Type | Prefix | Purpose | Base Branch | Lifespan | Merge Method |
|---|---|---|---|---|---|
| Feature | `feature/` | New functionality or enhancement | `main` | ≤ 3 days | Squash-merge |
| Fix | `fix/` | Bug fix | `main` | ≤ 3 days | Squash-merge |
| Chore | `chore/` | Non-functional changes (deps, config, tooling) | `main` | ≤ 3 days | Squash-merge |
| Refactor | `refactor/` | Code restructuring without behavior change | `main` | ≤ 3 days | Squash-merge |
| Docs | `docs/` | Documentation-only changes | `main` | ≤ 3 days | Squash-merge |
| Test | `test/` | Test-only additions or changes | `main` | ≤ 3 days | Squash-merge |
| Security | `security/` | Security fixes or hardening | `main` | ≤ 2 days | Squash-merge |
| Agent | `agent/` | Agent-authored branches (auto-deleted on merge) | `main` | ≤ 3 days | Squash-merge |
| Release | `release/` | Release stabilization and backports | `main` | Until release | Merge commit |
| Hotfix | `hotfix/` | Urgent production fix | `main` | ≤ 24 hours | Merge commit |
| Experiment | `exp/` | Throwaway exploration (DO NOT merge) | `main` or any | ≤ 7 days | N/A (delete) |

### 3.2 Naming Rules

- **Separator:** Hyphens (`-`) between words. No underscores or camelCase in branch names.
- **Short description:** 2–5 words, lowercase, descriptive of the change.
- **Reference ID:** Always include the issue/task/story ID where applicable.
  - Task/feature: `PPP-NNN` (e.g., `feature/add-task-validation-PPP-031`)
  - Bug fix: `ISSUE-NNN` or `BUG-NNN` (e.g., `fix/login-error-BUG-142`)
  - Chore: optional reference, but preferred (e.g., `chore/update-deps-PPP-110`)
  - Agent branch: `agent/<plan-id>-<step>` (e.g., `agent/plan-2026-07-10-setup-3`)
- **Length:** Maximum 72 characters total. Keep descriptions concise.
- **Forbidden characters:** Spaces, underscores, control characters, `..` sequences, `~`, `^`, `:`, `?`, `*`, `[`, `\`.

### 3.3 Branch Naming Examples

| Scenario | Branch Name |
|---|---|
| New task creation feature | `feature/create-task-PPP-031` |
| Fix login validation bug | `fix/login-validation-BUG-142` |
| Update npm dependencies | `chore/update-deps-PPP-110` |
| Refactor auth middleware | `refactor/auth-middleware-PPP-015` |
| Add architecture documentation | `docs/architecture-overview-PPP-007` |
| Add unit tests for task module | `test/task-module-coverage-PPP-038` |
| Fix XSS vulnerability | `security/xss-sanitization-PPP-050` |
| Agent implementation step | `agent/plan-setup-db-2` |
| Release v1.2.0 stabilization | `release/v1.2.0` |
| Emergency fix for production outage | `hotfix/prod-outage-2026-07-10` |
| Spike on WebSocket approach | `exp/websocket-spike` |

### 3.4 Branch Name Validation

Every branch push is validated by a CI pre-receive hook or GitHub Action that enforces:

```
^(feature|fix|chore|refactor|docs|test|security|agent|release|hotfix|exp)\/[a-z0-9-]+(-[A-Z]+-\d+)?$
```

Branches that don't match this pattern are rejected.

---

## 4. Branch Lifecycle & Strategy

### 4.1 Trunk-Based Development

The organization follows **trunk-based development** with short-lived feature branches:

```
       main (protected, always deployable)
        │
        ├── feature/add-task-PPP-031   (≤ 3 days)
        │       │
        │       └── merged via squash
        │
        ├── fix/login-validation-BUG-142 (≤ 3 days)
        │       │
        │       └── merged via squash
        │
        ├── release/v1.2.0             (until release)
        │       │
        │       └── merged via merge commit
        │
        └── hotfix/prod-outage         (≤ 24 hours)
                │
                └── merged via merge commit
```

### 4.2 Branch Lifecycle State Machine

```
                  ┌──────────────┐
                  │  Created     │
                  └──────┬───────┘
                         │
                         v
                  ┌──────────────┐
                  │  Active      │ (commits being pushed)
                  └──────┬───────┘
                         │
                         v
                  ┌──────────────┐
                  │  In Review   │ (PR opened, review in progress)
                  └──────┬───────┘
                         │
              ┌──────────┴──────────┐
              v                     v
    ┌────────────────┐    ┌────────────────┐
    │  Merged        │    │  Abandoned     │
    │  (delete       │    │  (delete       │
    │   remote       │    │   remote       │
    │   branch)      │    │   branch,      │
    └────────────────┘    │   close PR)    │
                          └────────────────┘
```

### 4.3 Branch Creation Rules

1. Always branch from the latest `main`.
2. Run `git fetch origin && git checkout -b <branch-name> origin/main` to ensure you branch from the latest state.
3. If `main` has advanced while your branch is active, rebase (never merge `main` into your feature branch):
   ```
   git fetch origin
   git rebase origin/main
   ```
4. **Never commit directly to `main`.** All changes enter `main` through PRs.
5. **Never force-push to `main`.** Force-push is allowed only on non-protected feature branches (to rebase).

### 4.4 Branch Deletion

- After merge: delete the remote branch immediately (GitHub does this automatically via the PR merge button).
- Abandoned branches: delete after 30 days of inactivity.
- Local branches: prune regularly with `git fetch --prune` and `git branch -d <merged-branch>`.

---

## 5. Commit Standards — Conventional Commits

All commits MUST follow the [Conventional Commits](https://www.conventionalcommits.org/) specification (v1.0.0).

### 5.1 Format

```
<type>(<scope>): <description>

[optional body]

[optional footer(s)]
```

### 5.2 Types

| Type | When to Use | Example |
|---|---|---|
| `feat` | A new feature | `feat(tasks): add create task endpoint` |
| `fix` | A bug fix | `fix(auth): handle invalid refresh token gracefully` |
| `chore` | Maintenance, deps, config | `chore(deps): update MediatR to v12.2` |
| `docs` | Documentation changes | `docs(api): add OpenAPI summary for task endpoints` |
| `refactor` | Code change with no behavior change | `refactor(tasks): extract validation logic` |
| `test` | Test additions or changes | `test(tasks): add unit tests for CreateTaskHandler` |
| `perf` | Performance improvement | `perf(calendar): optimize date range query` |
| `build` | Build system or external dependency changes | `build(backend): add Dockerfile for API` |
| `ci` | CI/CD pipeline changes | `ci(devops): add lint step to workflow` |
| `security` | Security fix or hardening | `security(auth): add rate limiting to login` |

### 5.3 Scope

Scope indicates the module or area of the codebase affected. Use short, consistent scopes:

| Repository | Common Scopes |
|---|---|
| Backend projects | `auth`, `tasks`, `projects`, `notes`, `calendar`, `notifications`, `dashboard`, `upload`, `identity`, `api`, `db`, `infra` |
| Frontend projects | `ui`, `components`, `pages`, `hooks`, `api-client`, `state`, `routing`, `styles` |
| Infrastructure | `ci`, `cd`, `docker`, `helm`, `terraform`, `monitoring` |
| Cross-cutting | `docs`, `deps`, `config`, `security`, `test` |

### 5.4 Description

- Imperative mood: "add", "fix", "update" — not "added", "fixed", "updated".
- Capitalize the first letter.
- No period at the end.
- Maximum 72 characters.
- Must be meaningful on its own. Bad: `fix stuff`. Good: `fix(auth): reject expired access tokens with 401`.

### 5.5 Body

The body is optional but SHOULD be provided for non-trivial changes:

```
feat(tasks): add create task command with validation

Implements the CreateTaskCommand handler with FluentValidation rules for
title length (1-200 chars), description max (2000 chars), and future-only
due date validation. Returns 201 Created with location header.

Plan: .omc/plans/plan-2026-07-task-mgmt.md
Refs: PPP-031
```

### 5.6 Footers

Standard trailers that MUST be included where applicable:

| Trailer | Required When | Example |
|---|---|---|
| `Refs:` | Always (task/issue reference) | `Refs: PPP-031` |
| `Closes:` | PR closes an issue | `Closes: #142` |
| `Plan:` | Agent-authored commits | `Plan: .omc/plans/plan-setup-db.md` |
| `Co-Authored-By:` | Agent-authored commits | `Co-Authored-By: executor-agent <agent@org.com>` |
| `BREAKING CHANGE:` | Breaking API or behavior change | `BREAKING CHANGE: /api/v1/tasks response envelope changed` |

### 5.7 Agent Commit Trailers

Agent-authored commits MUST include:

```
Co-Authored-By: <agent-type> <agent-id>@agents.internal
Plan: .omc/plans/<plan-id>.md
Refs: <task-id>
```

### 5.8 Commit Size Guidelines

- **One logical change per commit.** Don't bundle unrelated changes.
- **Target: ≤ 200 lines changed per commit.** Larger commits should be split.
- **A commit should pass CI independently** (though this is not always practical for multi-step features — at minimum, the PR as a whole must pass).

### 5.9 Prohibited Commit Patterns

| Pattern | Why Forbidden |
|---|---|
| `fix stuff`, `update`, `wip` | Non-informative; violates traceability |
| `oops`, `fix typo`, `undo` | Should be squashed before merge |
| `merge branch 'main' into feature/xxx` | Use rebase instead |
| Bundle of unrelated changes in one commit | Violates single concern principle |
| Commits with CI-breaking state (unless WIP) | `main` must always be green |

---

## 6. Pull Request Standards

### 6.1 PR Creation Rules

1. **One PR per concern.** A PR addresses exactly one feature, fix, or chore.
2. **PR size limit:** Maximum 800 lines changed across maximum 25 files. Larger PRs must be split (exceptions: mass renames labeled `mass-rename`, generated code).
3. **PR title:** Must be a valid Conventional Commit: `type(scope): description`.
4. **PR description:** Must use the mandatory PR template (see AAOS Appendix B or repository `PULL_REQUEST_TEMPLATE.md`).
5. **Linked artifacts:** Every PR must link to:
   - At least one issue or task ID (`Closes #NNN` or `Refs PPP-NNN`)
   - Risk class label (`R0`–`R4`)
   - Agent label (`agent-authored`) if agent-created
6. **Draft PRs:** Use draft PR state for work-in-progress. Mark as "Ready for Review" only when all checks pass.

### 6.2 PR Title Examples

| Type | Title |
|---|---|
| Feature | `feat(tasks): implement create task endpoint (PPP-031)` |
| Fix | `fix(auth): handle expired refresh tokens (BUG-142)` |
| CI | `ci(devops): add lint checks to CI pipeline (PPP-111)` |
| Docs | `docs(api): document task search parameters (PPP-036)` |

### 6.3 PR Review Requirements by Risk Class

| Risk Class | Human Reviewers | Agent Reviewers | Security Review | Architectural Review |
|---|---|---|---|---|
| R0 — Trivial | Optional (1 minimum) | Optional | Optional | Not required |
| R1 — Routine | 1 | 1 | Not required | Not required |
| R2 — Scoped | 1 | 1 | Required | Not required |
| R3 — Cross-cutting | 2 | 1 | Required | Required |
| R4 — Critical | 2 | 1 | Required + Security Officer | Required + Architect |

### 6.4 PR Labels

Every PR MUST carry at least these labels:

- **Risk class:** `risk:R0`, `risk:R1`, `risk:R2`, `risk:R3`, `risk:R4`
- **Origin:** `human-authored` or `agent-authored`
- **Area:** `area:backend`, `area:frontend`, `area:infra`, `area:docs`, `area:test`

Optional labels:

- `do-not-merge` — blocks merge
- `mass-rename` — bypasses file-count check
- `security-fix` — triggers additional security review
- `hotfix` — expedited process

### 6.5 PR Checklist (Mandatory)

Before marking a PR as ready for review, verify:

- [ ] PR title follows Conventional Commits format
- [ ] PR description uses the mandatory template
- [ ] All acceptance criteria from the task are addressed
- [ ] Tests pass (local run: `dotnet test` + `npm test`)
- [ ] Lint/format clean (`dotnet format --verify-no-changes` + `npm run lint`)
- [ ] No secrets, credentials, or tokens in code
- [ ] No TODOs without a follow-up issue reference
- [ ] Documentation updated (README, ARCHITECTURE.md, OpenAPI, ADRs)
- [ ] Branch is up-to-date with `main` (rebased, not merged)
- [ ] No scope creep — only the changes described

---

## 7. Code Review Process

### 7.1 Review Expectations

- **Reviewers** are responsible for verifying correctness, style, security, and adherence to standards.
- **Authors** are responsible for responding to all comments and either fixing or explaining.
- **Reviewers must read the full diff** (not just skim).
- **CI must be green** before human review begins.

### 7.2 Review Tiers

| Tier | Trigger | Required Participants |
|---|---|---|
| **Self-review** | Every PR before requesting review | Author runs through §6.5 checklist |
| **Peer review** | All PRs | At least 1 human reviewer |
| **Agent review** | R1+ PRs | Automated reviewer agent (different model than executor) |
| **Security review** | R2+ PRs, or any PR touching auth/security | Security validator agent + optional human |
| **Architecture review** | R3+ PRs | Architect or senior engineer |

### 7.3 Review Verdicts

| Verdict | Meaning | Action Required |
|---|---|---|
| **APPROVE** | Ready to merge | None (merge when checks pass) |
| **COMMENT** | Suggestion, non-blocking | Author may address or defer |
| **REQUEST_CHANGES** | Must fix before merge | Author fixes, re-requests review |

A reviewer who issues `REQUEST_CHANGES` must cite the specific rule or principle violated.

### 7.4 Reviewer Independence

- Agent reviewers must be from a **different dispatch lineage** than the executor.
- Agent reviewers should use a **different model family** than the executor (see AAOS §12.4).
- No reviewer may approve their own PR.

---

## 8. Merge Strategies

### 8.1 Strategy Selection

| Branch Source | Branch Target | Merge Strategy | Rationale |
|---|---|---|---|
| `feature/*`, `fix/*`, `chore/*`, `refactor/*`, `docs/*`, `test/*`, `security/*`, `agent/*` | `main` | **Squash-merge** | Keeps `main` history clean; one commit per feature |
| `release/*` | `main` | **Merge commit** | Preserves release branch topology; enables rollback tracking |
| `hotfix/*` | `main` | **Merge commit** | Preserves hotfix context; cherry-pick to release branches |
| `main` | `release/*` | **Fast-forward or merge commit** | Forward-port fixes |
| `exp/*` | N/A | **Delete branch** | Never merged |

### 8.2 Squash-Merge Commit Format

When squash-merging, the squashed commit message MUST follow:

```
<pr-title>

<pr-body-summary>

Closes: #<pr-number>
Refs: <task-id>
Co-Authored-By: <author(s)>
```

### 8.3 Merge Commit Format

When using merge commits:

```
Merge branch '<source>' into '<target>'

<summary of changes>

Refs: <pr-number>
```

### 8.4 Prohibited Merge Operations

| Operation | Why Forbidden |
|---|---|
| Rebasing `main` | Rewrites shared history |
| Force-push to `main` or `release/*` | Destroys history; bypasses protections |
| Merging a PR without all checks green | Breaks `main` invariant |
| Merging own PR | Bypasses review |
| Fast-forward merge of feature branches to `main` | Loses PR context; use squash instead |
| Squash-merge of `release/*` or `hotfix/*` to `main` | Loses release topology |

---

## 9. Release Workflow

### 9.1 Release Process

```
1. Freeze: Tag the current `main` as the release candidate
   └─ git tag v1.2.0-rc.1 main && git push origin v1.2.0-rc.1

2. Stabilize: Cut release branch
   └─ git checkout -b release/v1.2.0 main

3. Validate: Run full test suite, security scan, perf test
   └─ CI runs full suite against release/v1.2.0

4. Fix: Apply release-specific fixes as PRs to release/v1.2.0
   └─ fix/* commits cherry-picked or PR'd to release branch

5. Ship: Merge release/v1.2.0 to main with merge commit
   └─ PR: release/v1.2.0 → main (merge commit, not squash)

6. Tag: Create the release tag on main after merge
   └─ git tag v1.2.0 && git push origin v1.2.0

7. Deploy: Progressive rollout (10% → 50% → 100%)
   └─ Monitored by Argo/CI via release tag

8. Verify: Post-deployment validation
   └─ Smoke tests, telemetry observation (15 min minimum)
```

### 9.2 Versioning

Follow [Semantic Versioning 2.0.0](https://semver.org/):

- **MAJOR** (x.0.0): Breaking API or behavior changes
- **MINOR** (0.x.0): New feature, backward-compatible
- **PATCH** (0.0.x): Bug fix, backward-compatible

### 9.3 Changelog

Every release updates `CHANGELOG.md` per [Keep a Changelog](https://keepachangelog.com/) format. The changelog is generated from Conventional Commits between the last release tag and the new one.

### 9.4 Hotfix Process

```
1. Branch: git checkout -b hotfix/critical-fix main
2. Fix: Implement the fix
3. PR: hotfix/critical-fix → main (merge commit, expedited review)
4. Tag: git tag v1.2.1 && git push origin v1.2.1
5. Backport: Cherry-pick the fix commit to active release branches
   └─ git checkout release/v1.2.0
   └─ git cherry-pick -x <fix-commit-sha>
   └─ git push origin release/v1.2.0
```

---

## 10. CI/CD Integration

### 10.1 Workflow Triggers

| Event | Action |
|---|---|
| Push to any branch | Run lint, type-check, unit tests |
| PR opened / synchronized | Run full CI suite (build, lint, test, scan, coverage) |
| PR labeled `ready-for-review` | Trigger agent review assignment |
| Push to `main` | Run full CI + deploy to staging |
| Tag push (`v*`) | Run full CI + deploy to production |
| Scheduled (nightly) | Full test suite + security scan + SBOM generation |

### 10.2 CI Must-Check Gates

1. Build succeeds (backend + frontend)
2. Lint passes (zero errors, zero warnings)
3. Type check passes
4. Unit tests pass (≥ 80% coverage on changed lines)
5. Integration tests pass
6. SAST scan: zero HIGH/CRITICAL findings
7. Secret scan: zero leaks
8. Dependency scan: no NEW HIGH/CRITICAL CVEs
9. License audit: all dependencies on allowlist
10. Conventional Commit validation: PR title and commit messages parse

### 10.3 Commit Status Checks

Required status checks on `main` branch protection:

- `build` — project compiles
- `lint` — linter clean
- `test` — all tests pass
- `coverage` — meets threshold
- `sast` — security scan clean
- `secret-scan` — no secrets leaked
- `dep-scan` — no new vulnerabilities
- `conventional-commit` — PR title is valid Conventional Commit

---

## 11. Git Configuration & Hygiene

### 11.1 Required Git Configuration

All contributors (human and agent) MUST configure:

```bash
git config --global user.name "Your Name"
git config --global user.email "your-email@organization.com"
git config --global pull.rebase true
git config --global fetch.prune true
git config --global diff.renames copies
git config --global core.autocrlf input  # Linux/Mac
git config --global core.autocrlf true   # Windows
```

Agent configurations MUST include agent-type and agent-id in the name:

```bash
git config user.name "executor-agent (plan-setup-db)"
git config user.email "executor-agent@agents.internal"
```

### 11.2 `.gitignore` Standards

Every repository root MUST have a `.gitignore` that covers at minimum:

```
# OS files
.DS_Store
Thumbs.db

# IDE
.idea/
.vscode/
*.swp
*.swo
*~

# Build artifacts
dist/
build/
bin/
obj/
*.exe
*.dll

# Dependencies
node_modules/
packages/

# Environment
.env
.env.local
.env.*.local
*.local.*

# Logs
*.log
logs/

# Coverage
coverage/
*.coverage.*

# Secrets
**/appsettings.*.local.json
secrets/
*.key
*.pem
```

### 11.3 EditorConfig

All repositories use `.editorconfig` for cross-editor consistency:

```ini
root = true

[*]
charset = utf-8
end_of_line = lf
insert_final_newline = true
trim_trailing_whitespace = true

[*.{cs,cshtml}]
indent_style = space
indent_size = 4

[*.{js,ts,jsx,tsx,json,yml,yaml,css,scss,html}]
indent_style = space
indent_size = 2

[*.md]
trim_trailing_whitespace = false
```

### 11.4 Git Hooks

Recommended local Git hooks (managed via `husky` for frontend, or `.githooks/`):

| Hook | Action |
|---|---|
| `pre-commit` | Run linter on staged files; run secret scan |
| `commit-msg` | Validate Conventional Commit format |
| `pre-push` | Run full test suite |

---

## 12. Troubleshooting & Recovery

### 12.1 I committed to `main` by accident

```bash
# Create a branch with the commit, then reset main
git branch feature/my-feature
git push origin feature/my-feature
git reset --hard origin/main
git push origin main --force  # Only if not protected
```

### 12.2 I need to undo a merged commit on `main`

```bash
# Revert (not reset) — safe on shared branches
git revert <commit-sha>
git push origin main
```

### 12.3 My feature branch is behind `main`

```bash
git fetch origin
git rebase origin/main
# If conflicts: resolve them, then git rebase --continue
```

### 12.4 I accidentally merged `main` into my feature branch

```bash
# Undo the merge commit while keeping your changes
git reset --hard HEAD~1
# Then rebase instead
git rebase origin/main
```

### 12.5 I need to split a large PR

1. Create multiple branches from `main`:
   ```bash
   git checkout main
   git checkout -b feature/part-1
   git cherry-pick <commit-sha>   # Pick commits for part 1
   git push origin feature/part-1
   ```
2. Repeat for remaining parts.
3. Open separate PRs for each part.

### 12.6 My commit message is wrong

If the commit hasn't been pushed:

```bash
git commit --amend -m "feat(tasks): correct message"
```

If the commit has been pushed (on a feature branch):

```bash
git commit --amend -m "feat(tasks): correct message"
git push origin feature/my-feature --force  # Only on non-protected branches
```

### 12.7 I accidentally force-pushed to a protected branch

This should be impossible due to branch protection. If it happened, escalate to repository admin immediately. The branch may need to be restored from the reflog.

---

## 13. Appendix A — Quick Reference Card

### Branch Creation

```
git fetch origin
git checkout -b feature/add-validation-PPP-031 origin/main
```

### Standard Workflow

```
# Create branch
git checkout -b feature/my-feature-PPP-031 origin/main

# Work, commit, repeat
git add <files>
git commit -m "feat(tasks): implement create task command"

# Stay up-to-date
git fetch origin
git rebase origin/main

# Push
git push origin feature/my-feature-PPP-031

# Open PR → review → merge → delete branch
```

### Commit Format

```
<type>(<scope>): <description>

[body — why, not what]

[footer — Refs:, Closes:, Plan:, Co-Authored-By:]
```

### Common Branch Types

| Type | Prefix | Merge To | Merge Method |
|---|---|---|---|
| Feature | `feature/` | `main` | Squash |
| Fix | `fix/` | `main` | Squash |
| Chore | `chore/` | `main` | Squash |
| Hotfix | `hotfix/` | `main` | Merge commit |
| Release | `release/` | `main` | Merge commit |

---

## 14. Appendix B — Workflow Decision Trees

### B.1 "What branch type should I use?"

```
Is this fixing a production bug?
  yes → Is it urgent (≤ 24h)?
          yes → hotfix/
          no  → fix/
  no  → Is this a new feature?
          yes → feature/
          no  → Is this a maintenance task (deps, config, tooling)?
                  yes → chore/
                  no  → Is this a documentation change?
                          yes → docs/
                          no  → Is this a refactor with no behavior change?
                                  yes → refactor/
                                  no  → Is this a test-only change?
                                          yes → test/
                                          no  → Is this a security fix?
                                                  yes → security/
                                                  no  → Is this exploratory/spike?
                                                          yes → exp/
                                                          no  → Escalate
```

### B.2 "Should I merge or rebase?"

```
Am I on a shared branch (main, release/*)?
  yes → Never rebase or force-push. Use merge for forward-port.
  no  → Is my feature branch published and others have pulled it?
          yes → Merging main into feature is tolerable, but rebase is preferred.
                Coordinate with teammates first.
          no  → Always rebase on main. No merge commits in feature branches.
```

### B.3 "How should I merge this PR?"

```
What branch is being merged to main?
  feature/*, fix/*, chore/*, refactor/*, docs/*, test/*, security/*, agent/*
    → Squash-merge (clean history, one commit per feature)
  release/*
    → Merge commit (preserves topology, enables rollback tracking)
  hotfix/*
    → Merge commit (preserves hotfix context, enables cherry-pick)
```

### B.4 "Is my branch name valid?"

```
Does it match ^(feature|fix|chore|refactor|docs|test|security|agent|release|hotfix|exp)\/[a-z0-9-]+(-[A-Z]+-\d+)?$ ?
  yes → Valid
  no  → Follow Section 3 rules and retry
```

---

**End of Git Workflow Standard.**

This document is binding on every Git operation in every organizational repository. Amendments require: Architect approval, Security Officer approval, and a 7-day comment window. PRs proposing amendments must link this document as the changed baseline.
