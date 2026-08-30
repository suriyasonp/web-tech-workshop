# Workshop Recovery on `main`

`main` is the source of truth for all workshop material. Students build cumulatively under `student/starter/`, while the verified application under `instructor/solutions/` is the comparison and classroom recovery source.

## Student Recovery

1. Save the student's current work with a commit or a copy.
2. Identify the last lab that passed its Validation section.
3. Compare the relevant files with `instructor/solutions/backend/` or `instructor/solutions/frontend/`.
4. Bring across only the minimum needed change, then continue on `main`.

Do not delete the repository or replace the whole student working area for a targeted failure.

## Legacy Branches

The remote `lab-*-start`, `lab-*-solution`, `checkpoint-*`, and `workshop-materials` branches currently resolve to the same historical CI-verified tree. They are retained to avoid destructive branch changes, but the current teaching flow does not ask students to switch to them.

Before delivery, instructors should run:

```bash
git switch main
bash scripts/validate-materials.sh
dotnet test instructor/solutions/backend/WebTechWorkshop.sln
cd instructor/solutions/frontend
npm ci
npm run build
```
