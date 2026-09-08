# Lab 14 — Verify and Demonstrate the Complete Application

**Duration:** 45 minutes  
**Goal:** Prove the project works from clean dependencies through the complete user flow.

## Starting Point

Continue from Lab 13. Save work with a commit before final verification.

## Exercise 1 — Run local quality gates

From repository root, macOS:

```bash
bash scripts/validate-materials.sh
dotnet test student/starter/backend/WebTechWorkshop.sln
cd student/starter/frontend
npm ci
npm run build
```

Windows PowerShell:

```powershell
& "C:\Program Files\Git\bin\bash.exe" scripts/validate-materials.sh
dotnet test student/starter/backend/WebTechWorkshop.sln
Set-Location student/starter/frontend
npm ci
npm run build
```

## Exercise 2 — Run the acceptance journey

Start API and frontend using `docs/run-guide.md`. As Instructor:

1. login;
2. view the seeded list;
3. create a uniquely named task;
4. edit its status to Done;
5. refresh and prove persistence;
6. delete it.

Repeat as Student and verify Delete is hidden and a direct DELETE receives 403.

## Exercise 3 — Browser evidence

Run the documented Playwright flow when available, or open the latest GitHub Actions browser artifact. Confirm screenshots for Login, list, created task, and completed task.

## Exercise 4 — Push and inspect CI

```bash
git status
git add student/starter
git commit -m "feat: complete workshop task application"
git push
```

Open the GitHub Actions run and wait for material validation, backend, and frontend/E2E jobs.

## Validation

Local gates pass, the acceptance journey passes, and GitHub Actions is green.

## Recovery

Identify the first failing layer: material → compile → unit/integration → frontend build → browser flow. Compare only that segment with `instructor/solutions/`, repeat the failed check, then rerun the full gate.

## Expected result

A clean-install, test-backed, browser-verified application ready to demonstrate.

## Retrospective

Write one item each: **Keep**, **Improve**, and **Try next**.
