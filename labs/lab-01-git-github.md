# Lab 01 — Git and GitHub

## Objective
Practice a recoverable branch → commit → push workflow.

## Starting Point
Checkout `lab-01-start`, then create a personal branch: `git switch -c student/<name>`.

## Steps
1. Add a short learning goal to a new Markdown file.
2. Inspect `git status` and `git diff`.
3. Commit with `git commit -m "docs: add workshop goal"`.
4. Push with `git push -u origin student/<name>`.
5. Inspect `git log --oneline --decorate -5`.

## Validation
The personal branch exists remotely and the working tree is clean.

## Recovery
Use `lab-01-solution` to return to a known repository state; do not delete the repository.

## Expected Result
Participants can save work and explain branch, commit, remote, and HEAD.
