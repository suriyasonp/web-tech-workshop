# Workshop Checkpoints

Every lab has two named recovery refs:

- `lab-XX-start` — safe point to begin or restart the lab.
- `lab-XX-solution` — verified recovery point when the room must move forward.

The recovery refs intentionally use the latest CI-verified application tree. They prioritize a runnable class state over exposing a fragile partially implemented application. The lab document defines the learning delta; the solution ref provides a dependable comparison and emergency reset.

## Milestone Refs

- `checkpoint-backend-ready`
- `checkpoint-auth-ready`
- `checkpoint-frontend-ready`
- `checkpoint-final`

## Student Recovery

```bash
git fetch origin
git switch student/<name>
git status
git commit -am "checkpoint: save work before recovery"
git restore --source origin/lab-XX-solution -- src
```

For a complete reset, create a new branch from the selected checkpoint instead of deleting the current branch:

```bash
git switch -c recovery/lab-XX origin/lab-XX-solution
```

## Instructor Validation

CI validates that every lab document names both refs. Before delivery, run:

```bash
bash scripts/validate-materials.sh
git ls-remote --heads origin 'lab-*-start' 'lab-*-solution'
```
