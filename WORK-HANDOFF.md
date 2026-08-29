# Work Mode Handoff

## Goal

Turn the workshop-material foundation into a fully runnable, instructor-tested 2-day workshop.

## Source of Truth

- Agenda: `docs/agenda.md`
- Architecture: `docs/architecture.md`
- Labs: `labs/`
- Instructor guidance: `instructor/`
- Definition of Done: `CHECKLIST.md`

## Implementation Order

1. Build the **final backend** under `src/backend`
   - .NET 10 Minimal API
   - EF Core + SQLite
   - Task CRUD
   - Validation/error handling
   - JWT authentication/authorization
   - Unit tests

2. Build the **final frontend** under `src/frontend`
   - Vue + TypeScript + Vite
   - Router
   - Axios service layer
   - Login/token handling
   - Task CRUD UI
   - Loading/error states

3. Run the final application end-to-end.

4. Refine each lab so every instruction matches the real implementation.

5. Create reproducible Git checkpoints:
   - `lab-XX-start`
   - `lab-XX-solution`
   - `checkpoint-backend-ready`
   - `checkpoint-auth-ready`
   - `checkpoint-frontend-ready`
   - `checkpoint-final`

6. Author presentation files from `slides/README.md`.
   Keep slides conceptual; keep full code in labs/repository.

7. Add diagrams, screenshots, cheat sheets, and demo script.

8. Validate on a clean machine and complete `CHECKLIST.md`.

## Delivery Constraint

Workshop runs 12–13 September 2026, 08:30–18:00. Preserve the agenda timing and optimize material for third-year students doing a guided full-stack build.

## Teaching Principle

Use one continuous Task Management System throughout the workshop. Do not introduce unrelated sample applications between sessions.

## Definition of Success

A participant who starts from a clean environment can follow the labs in sequence and finish with the same working full-stack application used in the final demo.
