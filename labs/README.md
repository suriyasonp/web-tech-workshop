# Hands-on Labs

The two-day workshop builds one continuous Task Management System. Every lab defines a starting ref, concrete steps, an observable validation, and a recovery ref.

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

See [Lab-to-implementation map](implementation-map.md) and [checkpoint guide](../docs/checkpoints.md).

## Validation Contract

Before delivery, CI verifies:

- every Lab 00–14 file exists;
- every lab declares `lab-XX-start` and `lab-XX-solution`;
- every lab has an observable Validation section;
- backend tests, frontend build, and browser E2E pass;
- both PowerPoint decks and instructor recovery documents exist.
