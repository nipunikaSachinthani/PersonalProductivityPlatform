# Personal Productivity Platform — Engineering Principles (Operational)

**Document class:** Operational principles, agent-readable
**Authority:** The roadmap plan (`productivity_platform_roadmap_2001c371.plan.md`) and `ARCHITECTURE_ANALYSIS.md` are the canonical specs; this file is the day-to-day cheat-sheet.
**Audience:** Every agent and developer touching this repo.
**Conflict rule:** Roadmap plan > ARCHITECTURE_ANALYSIS.md > this file > all other docs.

---

## The six load-bearing convictions

1. **Determinism beats cleverness.** Boring, predictable implementations are worth ten clever ones.
2. **Traceability is non-negotiable.** If it didn't happen in Git, it didn't happen.
3. **Smallest viable change wins.** Three similar lines beat a premature abstraction.
4. **Security is precondition, not checklist.** Gates are mechanical.
5. **Humans decide, agents execute.** Strategy is human; tactics are agent.
6. **Memory lives in the repository.** No durable private agent memory.

## The five operational lenses

When evaluating any change, run it through these in order. Stop at the first failure.

1. **Does the roadmap plan require it?** If yes, proceed. If no, ask why.
2. **Is there a documented decision that covers this?** If yes, follow it. If it's an architectural choice not yet documented, record it in ARCHITECTURE_ANALYSIS.md.
3. **Is the smallest viable change defensible?** If you've added more than the task requires, cut it back.
4. **Does it have adequate test coverage?** Every new code path must have at least one test. Light tests (2–5) per early phase; comprehensive suite in Phase 10.
5. **Is the authorization boundary intact?** Users must only access their own data or their project's data. Resource-level authorization must be enforced at the API layer, never in the frontend alone.

## Defaults that you do not override without discussion

| Default | Override requires |
|---|---|
| .NET 8 Clean Architecture with CQRS (MediatR) | Documented decision in ARCHITECTURE_ANALYSIS.md |
| React 18 + TypeScript strict + Tailwind + shadcn/ui for UI | Documented decision |
| SQL Server with EF Core migrations (never manual DDL in production) | Documented decision |
| Soft delete where appropriate (Notes, Projects) | Documented decision |
| JWT + refresh tokens via ASP.NET Core Identity | Documented decision |
| RBAC, not ABAC — roles (Admin, User) with resource-level checks | Documented decision |
| Azure for cloud resources (App Service, SQL, Blob Storage) | N/A — project commitment |
| UTC timestamps everywhere (`DateTime.UtcNow`, `CreatedAt` / `UpdatedAt`) | none — non-negotiable |
| Conventional commit messages (`feat(scope): description`) | none — non-negotiable |
| `Result<T>` pattern for expected failures; global exception middleware for unexpected errors | Documented decision |

## Anti-patterns (refuse to ship)

- **Hard DELETE on entities marked for soft delete** — use `IsArchived = true` or equivalent.
- **Hand-rolled crypto or custom auth logic** — use ASP.NET Core Identity + built-in JWT middleware.
- **Database access from frontend** — frontends go through the API only. No direct DB queries from React.
- **Cross-module DB queries bypassing the API** — use the owning module's repository/API.
- **User credentials, tokens, or personal data in logs** — strip before logging.
- **Background jobs without idempotency** — every Hangfire/background handler must be safe to retry.
- **Server-echoing client-supplied IDs** — server generates IDs via EF Core, never trusts client input for identity.
- **Magic config** — every behavior discoverable in `appsettings.json`, User Secrets, or environment variables.
- **Speculative abstractions** — three call sites or it stays inline. No generic frameworks for a single consumer.
- **Defensive `try/catch` that swallows** — fail loud, fail safe. Log errors with context.
- **Production secrets in plain `appsettings.json`** — use User Secrets (development) and Azure Key Vault / GitHub Secrets (production).
- **One-off scripts that mutate production data** — database changes go through EF Core migrations checked into source control.

## Communication style (apply to every PR description, decision record, escalation)

- State the **why** before the **what**.
- One claim per sentence; bullet lists for parallel facts.
- Numbers over adjectives. "API response p95 120ms" beats "fast."
- Trade-offs are explicit: "chose X over Y because Z; the cost is W."
- Failure modes named, not hinted at.

## Cost-awareness

- LLM-backed features default to the cheapest viable model.
- Prompt caching is mandatory on system + tools + few-shot blocks.
- Token budget is enforced pre-flight. Reject before call.
- Azure costs tracked: App Service (B1 ~$13/mo + scale), Azure SQL (Basic ~$5/mo), Blob Storage (~$0.02/GB). Stay within free/student credits where possible.

## Risk-aware engineering

- Routine work needs no extra ceremony.
- Cross-module work (touching 2+ modules or changing the API contract) needs documented reasoning.
- New technology/library additions need a justification in the PR description.
- Every PR self-assesses scope; the reviewer challenges scope creep upward, never downward.

## Definition of done

- Acceptance criteria from the task prompt all ticked, with evidence.
- Lint + typecheck + test green (commands pasted, not asserted):
  - Backend: `dotnet format --verify-no-changes` + `dotnet test`
  - Frontend: `npm run lint` + `npm run typecheck` + `npm test`
- Light tests (2–5) added for early phases; comprehensive suite in Phase 10.
- No new TODOs without a follow-up task reference or GitHub issue link.
- `ARCHITECTURE_ANALYSIS.md` reflects what the code now does if this change alters a pattern, convention, or technology choice.
