# Prompt: Generate Phase-Wise Task Specs for Personal Productivity Platform

**Use:** Paste this into any AI coding agent with the roadmap plan file and
the adapted governance files as context. Output goes to `prompts/tasks/`.

---

## Input Files (load these before generating)

1. `productivity_platform_roadmap_2001c371.plan.md` — the 12-phase roadmap
2. `ARCHITECTURE_ANALYSIS.md` — technology stack and conventions
3. `ENGINEERING_MATURITY.md` — current and target maturity levels

---

## Task

Generate a complete `prompts/tasks/` directory for the Personal Productivity
Platform. Create one phase folder per roadmap phase (`phase_01_Setup` through
`phase_12_Monitoring`), each containing individual task prompt files.

---

## Output Structure

```
prompts/
├── README.md                              # Index of all phases with task counts
└── tasks/
    ├── phase_01_Project_Setup/
    │   ├── README.md                      # Phase overview and task index
    │   ├── PPP-001.md                     # Individual task prompts
    │   ├── PPP-002.md
    │   └── ...
    ├── phase_02_Authentication/
    │   ├── README.md
    │   ├── PPP-010.md
    │   └── ...
    ├── phase_03_Task_Management/
    ...
    └── phase_12_Monitoring_Evolution/
        ├── README.md
        └── ...
```

---

## Naming Convention

Use `PPP-<NNN>` for task IDs, where `NNN` is a zero-padded sequence starting at
`001`. Number sequentially across all phases (not resetting per phase) so every
task has a unique ID.

**Phase number ranges:**
- Phase 01: PPP-001 through PPP-008
- Phase 02: PPP-010 through PPP-020
- Phase 03: PPP-030 through PPP-038
- ...and so on (use the next tens block for each phase).

---

## Task Prompt File Template

Every task prompt file must follow this exact structure:

```markdown
# Task Prompt — {TASK_ID}

> Read prerequisites first: the project roadmap, AAOS.md, PRINCIPLES.md,
> ARCHITECTURE_ANALYSIS.md, and ENGINEERING_MATURITY.md.

---

## 1. Task Identity

| Field | Value |
|---|---|
| **Task ID** | `PPP-NNN` |
| **Phase** | Phase NN — {Phase Name} |
| **Module** | {the module this task belongs to: Setup, Auth, Tasks, Projects, Notes, Calendar, Notifications, Dashboard, Attachments, Testing, DevOps, Monitoring} |
| **Priority** | P0 / P1 / P2 |
| **Estimate** | {hours or days} |
| **Dependencies** | {list of task IDs this depends on, or "None"} |
| **Risk Class** | R0 / R1 / R2 / R3 / R4 (per AAOS §8.2) |

**Risk classification guide:**
- **R0 — Trivial:** typo, comment, doc clarification. Solo execution.
- **R1 — Routine:** single-file code change with full tests, no external surface.
- **R2 — Scoped:** 2–5 files, no schema or contract change (or additive schema).
- **R3 — Cross-cutting:** contract, schema, or auth-touching change; mandatory ADR.
- **R4 — Critical:** production data, security boundary, multi-service, or compliance-impacting.

---

## 2. Objective

> {One sentence: what this task delivers}

{2–4 sentences: context from the roadmap — why this task exists, how it fits
into the phase, what concepts it teaches}

---

## 3. Pre-flight Checklist

Before implementing, confirm:
- [ ] Dependencies are complete (listed above)
- [ ] Read the project roadmap plan file
- [ ] Read AAOS.md (governance boundaries, quality gates, escalation rules)
- [ ] Read PRINCIPLES.md (operational cheat-sheet)
- [ ] Read ARCHITECTURE_ANALYSIS.md for relevant conventions
- [ ] Understand the stack: .NET 8 Clean Architecture, React+Tailwind+shadcn, SQL Server+EF Core
- [ ] If this task requires a decision not covered by docs, stop and ask

---

## 4. Technical Guidance

{Module-specific rules and conventions, drawn from ARCHITECTURE_ANALYSIS.md}

**Conventions for this module:**
- {convention 1}
- {convention 2}
- {convention 3}

**Concepts practiced in this task:**
- {engineering concept 1}
- {engineering concept 2}

---

## 5. Acceptance Criteria

- [ ] Objective implemented as stated above
- [ ] Code follows project conventions (naming, folder structure, API design)
- [ ] Validation on all inputs (FluentValidation on backend, Zod on frontend)
- [ ] No secrets in code (use User Secrets / env vars / .gitignore)
- [ ] Tests added: {number and type — e.g., 2 unit + 1 integration}
- [ ] All existing tests still pass — zero regressions
- [ ] ESLint / dotnet format clean
- [ ] Documentation updated if applicable (README, ARCHITECTURE.md)
- [ ] PR opened with description including what was done and how tested
- [ ] No scope creep — only what this task describes

---

## 6. Out of Scope (explicitly do NOT do these)

- Unrelated refactors outside this task's files
- Performance optimizations not required by ACs
- New third-party dependencies without checking the approved stack
- Features from future phases
- Changing the architecture pattern without discussion

---

## 7. Deliverables

1. **Branch:** `feature/PPP-NNN-{short-slug}` off `main`
2. **Commits:** Conventional format — `feat({module}): {description}`
3. **PR:** Description with what was done, how tested, and a test plan
4. **Tests:** At minimum, the light tests specified in the ACs

---

## 8. Verification Hints

```bash
# Backend
dotnet build && dotnet test
dotnet ef migrations list

# Frontend
npm run lint && npm run typecheck && npm run dev

# API smoke
curl http://localhost:5000/api/v1/health
```

---

## 9. Escalation Triggers

Stop and ask if:
- A dependency listed above is not complete
- You need a third-party package not in the approved stack
- The task requires a schema change not described here
- You discover a conflict between the roadmap and technical constraints
- You're spending more than 2x the estimate without a clear end in sight

---

## 10. Definition of Done

- All acceptance criteria checked off with evidence
- PR opened and self-reviewed against the checklist
- No TODOs left without a follow-up task reference
```

---

## How to Decompose Each Phase Into Tasks

For each phase from the roadmap, break it down as follows:

**Phase 01 — Project Setup:** Create one task per distinct deliverable.
- PPP-001: Initialize Git repo and folder structure
- PPP-002: Scaffold .NET Clean Architecture solution
- PPP-003: Scaffold React + Vite + Tailwind + shadcn UI
- PPP-004: Configure EF Core with LocalDB and initial migration
- PPP-005: Configure Swagger, Serilog, and appsettings
- PPP-006: Configure ESLint, Prettier, EditorConfig
- PPP-007: Create health check endpoint and landing page E2E
- PPP-008: Write light integration test for health endpoint

**Phase 02 — Authentication:** One task per distinct endpoint/user-story.
**Phase 03 — Task Management:** One task per CRUD operation + tests.
**Phases 04–09:** Follow the same pattern — decompose the roadmap's bullet
lists into individual task files.

**Phase 10 — Testing:** One task per test category (unit, integration, component).
**Phase 11 — DevOps:** One task per CI/CD concern (build, lint, test, deploy).
**Phase 12 — Monitoring:** One task per observability concern.

---

## Per-Phase README.md Template

Each phase folder gets a README.md:

```markdown
# Phase NN — {Phase Name}

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-001 | {one-line summary} | P1 | 2h | None |
| PPP-002 | {one-line summary} | P1 | 3h | PPP-001 |
| ... | ... | ... | ... | ... |

## Phase Goal
{One paragraph from the roadmap}

## Exit Criteria
- {criterion 1}
- {criterion 2}
```

---

## Root prompts/README.md Template

```markdown
# Personal Productivity Platform — Task Prompts

| Phase | Folder | Tasks | Status |
|---|---|---|---|
| 01 | phase_01_Project_Setup | 8 | pending |
| 02 | phase_02_Authentication | N | pending |
| ... | ... | ... | ... |
```

---

## Execution Instructions

Generate all files. Do not skip any phase. For each task:

1. Read the corresponding section in the roadmap plan
2. Read the relevant technology guidance from ARCHITECTURE_ANALYSIS.md
3. Fill the template with concrete, actionable content — no placeholders
4. Write the file to `prompts/tasks/phase_NN_Name/PPP-NNN.md`
5. Write the phase README.md
6. Write the root prompts/README.md

Output the complete directory structure when done.
