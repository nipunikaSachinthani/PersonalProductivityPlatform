# Personal Productivity Platform — Task Prompts

> Auto-generated from `productivity_platform_roadmap_2001c371.plan.md`, `ARCHITECTURE_ANALYSIS.md`, and `ENGINEERING_MATURITY.md`.
>
> Each task prompt file follows the standard template defined in `TaskPrompts/GENERATE_PHASE_SPECS.md`.

---

## Phase Index

| Phase | Folder | Tasks | Status |
|---|---|---|---|
| 01 | [phase_01_Project_Setup](tasks/phase_01_Project_Setup/) | 8 | pending |
| 02 | [phase_02_Authentication](tasks/phase_02_Authentication/) | 11 | pending |
| 03 | [phase_03_Task_Management](tasks/phase_03_Task_Management/) | 9 | pending |
| 04 | [phase_04_Projects](tasks/phase_04_Projects/) | 9 | pending |
| 05 | [phase_05_Notes](tasks/phase_05_Notes/) | 8 | pending |
| 06 | [phase_06_Calendar](tasks/phase_06_Calendar/) | 6 | pending |
| 07 | [phase_07_Notifications](tasks/phase_07_Notifications/) | 7 | pending |
| 08 | [phase_08_Dashboard](tasks/phase_08_Dashboard/) | 5 | pending |
| 09 | [phase_09_File_Uploads](tasks/phase_09_File_Uploads/) | 5 | pending |
| 10 | [phase_10_Testing](tasks/phase_10_Testing/) | 4 | pending |
| 11 | [phase_11_DevOps](tasks/phase_11_DevOps/) | 3 | pending |
| 12 | [phase_12_Monitoring](tasks/phase_12_Monitoring/) | 3 | pending |

**Total: 78 tasks across 12 phases**

---

## Task ID Ranges

| Phase | ID Range |
|---|---|
| 01 — Project Setup | PPP-001 to PPP-008 |
| 02 — Authentication | PPP-010 to PPP-020 |
| 03 — Task Management | PPP-030 to PPP-038 |
| 04 — Projects | PPP-040 to PPP-048 |
| 05 — Notes | PPP-050 to PPP-057 |
| 06 — Calendar | PPP-060 to PPP-065 |
| 07 — Notifications | PPP-070 to PPP-076 |
| 08 — Dashboard | PPP-080 to PPP-084 |
| 09 — File Uploads | PPP-090 to PPP-094 |
| 10 — Testing | PPP-100 to PPP-103 |
| 11 — DevOps | PPP-110 to PPP-112 |
| 12 — Monitoring | PPP-120 to PPP-122 |

---

## How to Use

1. **Start at Phase 01.** Each phase depends on the previous ones.
2. **Read the phase README.md** for an overview and task table.
3. **For each task**, read the full `PPP-NNN.md` file. It contains the objective, technical guidance, acceptance criteria, and out-of-scope boundaries.
4. **Follow the template.** Every task prompt has the same 10-section structure:
   - Task Identity (ID, phase, module, priority, estimate, dependencies)
   - Objective (what + why)
   - Pre-flight Checklist
   - Technical Guidance (conventions + concepts)
   - Acceptance Criteria
   - Out of Scope
   - Deliverables (branch, commits, PR)
   - Verification Hints (curl/npm commands)
   - Escalation Triggers (when to stop and ask)
   - Definition of Done
5. **Complete light tests per phase** (2–5 per phase, deferred comprehensive suite to Phase 10).
6. **Finish each phase completely before starting the next.** Partial completion across phases creates compounding technical debt.

---

## Prerequisites

Before implementing any task, read:

1. `GIT_WORKFLOW.md` — universal Git workflow standard (branch naming, commits, PRs, merge strategy) — **mandatory for every task**
2. `productivity_platform_roadmap_2001c371.plan.md` — the 12-phase roadmap
3. `AAOS.md` — governance boundaries, quality gates, escalation rules
4. `PRINCIPLES.md` — operational cheat-sheet (AAOS §2 applied daily)
5. `ARCHITECTURE_ANALYSIS.md` — technology stack, conventions, patterns
6. `ENGINEERING_MATURITY.md` — current and target maturity levels

---

## Technology Stack

| Layer | Technology |
|---|---|
| Frontend | React 18, TypeScript, Vite, Tailwind CSS, shadcn/ui, TanStack Query, React Hook Form + Zod, Recharts, FullCalendar, TipTap |
| Backend | .NET 8, Clean Architecture, MediatR (CQRS), FluentValidation, EF Core, Serilog, Hangfire |
| Database | SQL Server (LocalDB dev, Azure SQL prod) |
| Cloud | Azure App Service, Azure Blob Storage, Application Insights |
| DevOps | Git, GitHub, GitHub Actions |

---

## Engineering Maturity Progression

| Phase | Source Control | Testing | CI/CD | Docs | Architecture |
|---|---|---|---|---|---|
| 01 | L2 | L1 | L0 | L0 | L1 |
| 02 | L2 | L1 | L0 | L0 | L2 |
| 03–06 | L2 | L1 | L0 | L1 | L2–L3 |
| 07–09 | L2 | L1 | L0 | L1 | L3 |
| 10 | L3 | L3 | L0 | L2 | L3 |
| 11 | L3 | L3 | L3 | L2 | L3 |
| 12 | L4 | L4 | L4 | L3 | L4 |
