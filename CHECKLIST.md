# Workshop Material Definition of Done

## Application
- [x] Final backend restores, builds, and tests from a clean CI checkout
- [x] Final frontend installs and builds from a clean workspace
- [x] Login works through the API integration test
- [x] CRUD works through the API integration test
- [x] SQLite persistence works across an application restart
- [x] Backend unit and integration tests pass in CI

## Labs
- [x] Lab documents 00–14 created
- [x] Final implementation mapped to Labs 02–14
- [x] Lab contracts (start, steps, validation, recovery, expected result) validated in CI
- [x] Lab-specific start/solution recovery refs created and verified
- [x] Expected output screenshots captured by browser E2E and added

## Slides
- [x] Module plan created
- [x] Day 1 and Day 2 slide decks authored and render-tested
- [x] Architecture, request-flow, and delivery diagrams added
- [x] Demo transitions documented in speaker notes and rehearsal checklist

## Instructor
- [x] Day 1 notes created
- [x] Day 2 notes created
- [x] Common errors created
- [x] Detailed demo script created
- [x] Backup/fallback procedure documented
- [ ] Backup/fallback procedure tested in the room setup

## Delivery
- [x] Automated materials/backend/frontend/browser-E2E CI defined
- [ ] Environment verification completed on a clean student machine
- [ ] Repository access tested with a student account
- [x] Final demo tested through browser E2E
- [x] Emergency checkpoints created and verified against a CI-passing commit

## Current Evidence

- CI run [`33262545964`](https://github.com/suriyasonp/web-tech-workshop/actions/runs/33262545964) passed materials, backend, frontend, and end-to-end jobs.
- Browser screenshots are in `resources/screenshots/` and trace back to CI run `33262413430`.
- All 30 `lab-00` through `lab-14` start/solution refs resolve to the verified recovery tree.
- The remaining unchecked items require the actual classroom hardware or a real student account; they cannot be validated by repository automation.
