# Phase 12 — Monitoring & Architecture Evolution

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-120 | Configure Application Insights telemetry | P0 | 2h | All previous phases |
| PPP-121 | Structured Serilog JSON logging + custom metrics + health checks | P0 | 2h | PPP-120 |
| PPP-122 | Optional capstone: Extract Notification Service microservice | P2 | 3h | All previous phases |

## Phase Goal

Production-grade observability with Application Insights (request tracking, dependency tracing, exception monitoring), JSON structured logging, custom business metrics, and enhanced health checks. Optional capstone: extract Notification Service behind a message bus.

## Exit Criteria

- Application Insights collecting telemetry (requests, dependencies, exceptions)
- Serilog JSON output in production, human-readable in development
- Custom metrics tracked (login failures, task creation rate)
- Health checks verify database and blob storage connectivity
- Optional: Notification Service extracted, communicating via message bus
