# Lab 01 — Save Work with Git and GitHub

**Duration:** 25 minutes  
**Goal:** Create a branch, commit one safe change, and push it to GitHub.

## Before you begin

Complete Lab 00. Replace `<name>` below with a short lowercase name, for example `student/fore`.

## Exercise 1 — Start from current main

PowerShell and macOS Terminal use the same commands:

```bash
git switch main
git pull --ff-only
git status
git switch -c student/<name>
```

Expected: `Switched to a new branch`.

## Exercise 2 — Create and inspect a change

In VS Code, create `student/goals/<name>.md`:

```markdown
# My workshop goal

I want to build and understand one complete web feature.
```

Inspect before committing:

```bash
git status
git diff -- student/goals/<name>.md
git add student/goals/<name>.md
git diff --cached
```

Explain to a partner: working tree → staging area → commit.

## Exercise 3 — Commit and push

```bash
git commit -m "docs: add workshop goal"
git push -u origin student/<name>
git log --oneline --decorate -5
git status
```

Open the repository on GitHub and select your branch. Do not open a PR for this practice change unless the instructor requests it.

## Check your work

Your branch exists on GitHub, the commit is visible, and `git status` says the working tree is clean.

## Troubleshooting / instructor recovery

If the branch already exists, use `student/<name>-2`. For an authentication error, use [GitHub's official authentication guidance](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/about-authentication-to-github). Never delete or reclone the repository to fix an uncommitted change.

## Expected result

You can explain branch, commit, remote, push, and `HEAD`.
