# KU Web Technology Development Workshop

Delivery-ready material for a hands-on workshop at Kasetsart University, Sriracha Campus.

**Dates:** 12–13 September 2026  
**Time:** 08:30–18:00  
**Continuous application:** Task Management System

## Quick Start

`main` is the single teaching branch and source of truth.

```bash
git clone https://github.com/suriyasonp/web-tech-workshop.git
cd web-tech-workshop
git switch main
bash scripts/validate-materials.sh
```

Students start at [student/README.md](student/README.md). Instructors use [instructor/README.md](instructor/README.md), which includes the complete runnable solution and delivery material.

## Repository Map

- `student/labs/` — Lab 00–14 instructions
- `student/starter/` — Student working area and setup guidance
- `student/resources/` — Expected screenshots and supporting resources
- `instructor/solutions/` — Complete backend and frontend solution
- `instructor/slides/` — Day 1 and Day 2 presentation decks
- `instructor/` — Teaching notes, demo script, rehearsal, and troubleshooting
- `docs/` — Shared agenda, architecture, setup, recovery, branch audit, and run guide

## Workshop Flow

Real-world development → Agile + AI → architecture → REST → .NET Minimal API → EF Core → JWT → testing → Vue + TypeScript → Axios → full-stack CRUD → demo and retrospective.

Students stay on `main` for the workshop material and build each lab cumulatively under `student/starter/`. The old `lab-*`, `checkpoint-*`, and `workshop-materials` branches are retained as historical references, but they are not part of the current teaching flow.

## Run the Complete Solution

Follow the [final application run guide](docs/run-guide.md). The short verification commands are:

```bash
dotnet test instructor/solutions/backend/WebTechWorkshop.sln
cd instructor/solutions/frontend
npm ci
npm run build
```

## Visibility of Solutions

The instructor solution is intentionally kept in the same repository to make classroom recovery reliable. Students with repository access can read `instructor/solutions/`. Use a separate private repository if solutions must be hidden.

See [CHECKLIST.md](CHECKLIST.md) for the delivery definition of done.
