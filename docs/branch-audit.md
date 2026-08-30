# Legacy Branch Audit

Audit performed before the `main` consolidation.

## Findings

- `origin/main` pointed to `ec0873f` (the initial commit).
- `origin/workshop-materials` pointed to `22d3325`, 44 commits ahead of the old `main`.
- All 30 `lab-00` through `lab-14` start/solution branches pointed to `22d3325`.
- All four `checkpoint-*` branches pointed to `22d3325`.
- Because every lab and checkpoint branch exposed the same tree, they did not provide distinct starting or solution states.

## Decision

`main` was fast-forwarded through the full `workshop-materials` history, then reorganized into `student/` and `instructor/`. The legacy branches remain unchanged as historical references. No local or remote branch was deleted.

The current teaching flow uses only `main`; see [Workshop Recovery on `main`](checkpoints.md).
