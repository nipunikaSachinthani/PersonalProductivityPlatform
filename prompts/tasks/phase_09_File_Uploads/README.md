# Phase 09 — File Uploads

| Task ID | Description | Priority | Estimate | Dependencies |
|---|---|---|---|---|
| PPP-090 | Create Attachments schema + blob storage config | P0 | 1.5h | PPP-030 |
| PPP-091 | Implement file upload with validation + blob storage | P0 | 2.5h | PPP-090 |
| PPP-092 | Implement file download (SAS) + delete | P0 | 1.5h | PPP-091 |
| PPP-093 | Build drag-and-drop upload zone + file list UI | P1 | 1.5h | PPP-091, PPP-092 |
| PPP-094 | Write light tests for attachments | P1 | 1.5h | PPP-091, PPP-092 |

## Phase Goal

File attachments on tasks stored in Azure Blob Storage (Azurite locally). Drag-and-drop upload with progress, file type/size validation, SAS token-based download, and authorization (task owner/project member only).

## Exit Criteria

- File upload working with Azurite blob storage
- File type (images, PDFs, docs) and size (10MB) validation enforced
- SAS token download and delete working
- Drag-and-drop upload zone with progress bar on task detail
- Attachment list with download/delete actions
- 2 tests passing (file size validation, unauthorized upload)


---

## Git Workflow

Every task in this phase MUST follow `GIT_WORKFLOW.md` for branch naming, commit format, and PR standards. Before starting any task:
- Read `GIT_WORKFLOW.md` in full
- Create branches per §3 (Branch Naming Conventions)
- Write commits per §5 (Conventional Commits)
- Open PRs per §6 (Pull Request Standards)
