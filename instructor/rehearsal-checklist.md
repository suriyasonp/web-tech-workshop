# Instructor Rehearsal Checklist

## Automated Evidence

- Backend restore, build, and seven tests pass.
- Frontend clean install and production build pass.
- Browser completes Instructor login and CRUD.
- Browser confirms Student cannot delete.
- Four expected screenshots are uploaded from CI.
- Lab documents and presentation files pass material validation.

## 48 Hours Before Delivery

- Clone with the account students will use.
- Run `bash scripts/validate-materials.sh`.
- Run backend and frontend from the clone.
- Present both slide decks on the actual projector.
- Test Wi-Fi, GitHub, NuGet, npm, and browser ports.
- Download a repository archive for offline fallback.

## 30 Minutes Before Delivery

- Open Day 1 or Day 2 deck in presentation mode.
- Start the API and frontend.
- Reset `tasks.db` and complete the demo once.
- Open `checkpoint-final` and the matching lab solution branch.
- Keep `TaskApi.http`, CI evidence, and the fallback procedure ready.

## Transition Rehearsal

1. Explain the problem in one minute.
2. Use the slide’s concept or diagram.
3. Demonstrate one small code slice.
4. State the lab objective and completion check.
5. Set a timebox and announce the recovery ref.
6. Review the checkpoint before moving on.
