# Hands-on Labs

## HTML Reader

Students can read the published labs at
[suriyasonp.github.io/web-tech-workshop](https://suriyasonp.github.io/web-tech-workshop/).
The site is updated after a push to `main` that changes this directory.

For local preview, open [the lab reader](index.html) and run from the repository root:
`python -m http.server 8000`, then visit
`http://localhost:8000/student/labs/`. VS Code Live Server also works.
The reader loads Markdown directly, so edits appear after refreshing. An internet
connection is required for the pinned Markdown renderer and HTML sanitizer.
Share a specific page with `?lab=lab-00-environment.md` and a heading with its
table-of-contents link. Opening `index.html` directly via `file://` is not supported.

The two-day workshop builds one continuous Task Management System on `main`. Every lab defines a starting point, concrete steps, an observable validation, and a recovery path through `instructor/solutions/`.

## Day 1 — Foundation and Backend

- [Lab 00 — Environment Check](lab-00-environment.md)
- [Lab 01 — Git and GitHub](lab-01-git-github.md)
- [Lab 02 — .NET Minimal API](lab-02-minimal-api.md)
- [Lab 03 — First Task Endpoint](lab-03-first-endpoint.md)
- [Lab 04 — Task CRUD](lab-04-task-crud.md)
- [Lab 05 — EF Core and SQLite](lab-05-ef-core.md)
- [Lab 06 — Validation and Error Handling](lab-06-validation.md)
- [Lab 07 — Authentication and Authorization](lab-07-authentication.md)
- [Lab 08 — Backend Testing](lab-08-unit-testing.md)

## Day 2 — Frontend and Integration

- [Lab 09 — Vue and TypeScript Setup](lab-09-vue-setup.md)
- [Lab 10 — Layout and Routing](lab-10-layout-routing.md)
- [Lab 11 — Axios Integration](lab-11-axios.md)
- [Lab 12 — Frontend Login](lab-12-login.md)
- [Lab 13 — Task Management UI](lab-13-task-management.md)
- [Lab 14 — Final Integration](lab-14-final-integration.md)

See [Lab-to-implementation map](implementation-map.md) and [recovery guide](../../docs/checkpoints.md).

## Validation Contract

Before delivery, CI verifies:

- every Lab 00–14 file exists;
- every lab has a starting point and targeted recovery guidance;
- every lab has an observable Validation section;
- backend tests, frontend build, and browser E2E pass;
- both PowerPoint decks and instructor recovery documents exist.
