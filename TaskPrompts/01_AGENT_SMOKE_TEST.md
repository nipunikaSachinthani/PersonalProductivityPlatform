# Personal Productivity Platform — Agent Smoke Test

> **For validating an AI coding agent before any real work on this project.**
> This is a **read-only diagnostic**. The agent must not write files, create branches, install packages, push code, or open PRs.
> Expected runtime: 5–10 minutes.
> Outcome: a single Markdown report.

---

## How to Use This

1. Paste the **entire block below** (between the `===` markers) into your AI coding agent.
2. Replace the two placeholders:
   - `{{YOUR_NAME}}` — your name
   - `{{YOUR_PHASE}}` — the phase you will work on (01–12)
3. Send. Do nothing else.
4. When the agent returns its report, review it against the pass criteria at the bottom.
5. Any agent that fails goes back for re-configuration before being dispatched real tasks.

---

```
======================== PASTE THIS TO YOUR AGENT ========================

You are an AI coding agent assigned to the Personal Productivity Platform
project — a full-stack web application for task management, project
collaboration, notes, calendar, notifications, and analytics.

This is a SMOKE TEST. You are NOT executing engineering work.
You are proving that you can: read files, navigate the repo, follow the
mandated reading order, and produce a structured report.

================================  RULES  ================================

ABSOLUTE rules for this test:
1. Do NOT write, edit, or create any file.
2. Do NOT run git commit / git push / git branch / git checkout.
3. Do NOT install or upgrade any dependency.
4. Do NOT call any external API.
5. If you cannot read a file or do not understand something, REPORT IT —
   do not guess, do not fabricate content.

Your only deliverable is the structured Markdown report at the end.

================================  STEPS  ================================

STEP 1 — Read the project documents (in this exact order):
  a) productivty_platform_roadmap_2001c371.plan.md
  b) Temp/ARCHITECTURE_ANALYSIS.md
  c) Temp/ENGINEERING_MATURITY.md
  d) Temp/AI_OPERATING_SYSTEM_ROADMAP.md

STEP 2 — Capture quick comprehension proof. For each of the four files
   above, record:
   - the file's exact total line count (use a deterministic command like
     `wc -l` — do not estimate)
   - the title of the FIRST top-level heading (the first `# ` line)
   - one sentence in your own words describing what the file is for

STEP 3 — Knowledge probe. Answer these in your report.
   Use ONLY information from the documents above. If you can't find an
   answer, say "NOT FOUND" — do not invent.
   3.1 What is the official project name?
   3.2 What are the eight core modules of the platform?
   3.3 List the backend technology stack (framework, architecture pattern, ORM, database).
   3.4 What frontend technologies are used (framework, styling, form library, state management)?
   3.5 What cloud platform is used for deployment?
   3.6 How many phases are in the roadmap?
   3.7 What module is introduced in Phase 07 and what pattern does it teach?
   3.8 What does Phase 03 cover and what are its key engineering concepts?
   3.9 What is the target test coverage approach (how many tests per early phase)?
   3.10 What is the maturity scale range (L0 to L?) and what does L3 mean?

STEP 4 — Repo navigation probe. Locate (do not modify) and report the
   absolute paths of:
   4.1 The project roadmap plan file
   4.2 The architecture analysis file for this project
   4.3 The engineering maturity assessment file

STEP 5 — Phase prompt read probe. Read the roadmap plan file and report:
   5.1 The total number of phases (1 through 12)
   5.2 The name and goal of Phase {{YOUR_PHASE}} (use the phase number from {{YOUR_PHASE}})
   5.3 The first three tasks listed for Phase {{YOUR_PHASE}}
   5.4 Whether the phase requires light tests or comprehensive tests

STEP 6 — Escalation rehearsal. Without actually creating anything,
   produce a sample escalation ticket BODY (just the markdown text —
   do not file it anywhere) for this synthetic scenario:
     "The task asks me to implement a feature that requires a new
      third-party npm package not in the approved stack. What do I do?"

STEP 7 — Self-check. Confirm explicitly (yes/no, no waffle):
   7.1 Did you write or modify ANY file? (must be NO)
   7.2 Did you push, branch, or commit ANY code? (must be NO)
   7.3 Did you fabricate any answer? (must be NO)
   7.4 Did you read the roadmap plan file in full before answering
       the knowledge probe? (must be YES)
   7.5 Are you ready to receive your first real task? (must be YES)

================================  REPORT  ================================

Produce the report in this EXACT shape, then stop. Do not add commentary
before or after it.

# Personal Productivity Platform — Agent Smoke Test Report

**Developer:** {{YOUR_NAME}}
**Phase assigned:** {{YOUR_PHASE}}
**Date:** <UTC timestamp>
**Repo HEAD commit:** <git rev-parse HEAD>

## Step 2 — Comprehension proof
| File | Lines | First heading | One-line summary |
|------|------:|---------------|------------------|
| productivty_platform_roadmap_2001c371.plan.md | ... | ... | ... |
| Temp/ARCHITECTURE_ANALYSIS.md | ... | ... | ... |
| Temp/ENGINEERING_MATURITY.md | ... | ... | ... |
| Temp/AI_OPERATING_SYSTEM_ROADMAP.md | ... | ... | ... |

## Step 3 — Knowledge probe
3.1 ...
3.2 ...
3.3 ...
3.4 ...
3.5 ...
3.6 ...
3.7 ...
3.8 ...
3.9 ...
3.10 ...

## Step 4 — Repo navigation
4.1 ...
4.2 ...
4.3 ...

## Step 5 — Phase prompt read (Phase {{YOUR_PHASE}})
5.1 Total phases: ...
5.2 Phase {{YOUR_PHASE}} name and goal: ...
5.3 First three tasks:
    - ...
    - ...
    - ...
5.4 Test approach: ...

## Step 6 — Escalation rehearsal
<the synthetic escalation ticket body, fully filled in>

## Step 7 — Self-check
7.1 Wrote/modified a file? NO
7.2 Pushed/branched/committed? NO
7.3 Fabricated answers? NO
7.4 Read roadmap in full? YES
7.5 Ready for first real task? YES

---

END OF REPORT. Do not write anything after this line.

==========================  END OF PROMPT  ==========================
```

---

## What to Check in Each Report

| Check | Pass Criterion |
|---|---|
| All four reading-order files were read | Step 2 has correct line counts and matching first headings |
| Knowledge questions answered without hallucination | 3.1–3.10 match the documents; "NOT FOUND" used honestly when applicable |
| Agent could actually navigate the repo | Step 4 paths exist on disk |
| Agent understands the project scope | Step 5 answers match the roadmap plan |
| Agent understands when to escalate | Step 6 is coherent and identifies the right action |
| Agent obeyed the read-only constraint | Step 7 answers are all the required values |
| No file system or git side-effects | Repo `git status` is unchanged after the run |

**Any agent that fails on hallucination, ignores the read-only constraint, or skips the reading order is not cleared for real work.**

---

## Common Failure Modes

| Symptom | Diagnosis |
|---|---|
| Agent answers from training data instead of the file | Reading-order discipline is broken — re-prompt with mandatory file reads |
| Step 2 line counts are estimated, not exact | Agent isn't running shell commands |
| Step 3 fabricates module names or stack details | Hallucination — do not dispatch real tasks |
| Step 6 escalation skips the decision-needed field | Template not internalized |
| Step 7 contains anything other than the required YES/NO answers | Agent is improvising — tighten the prompt |
| Repo `git status` shows changes after the run | Hard fail — agent disobeyed read-only constraint |
