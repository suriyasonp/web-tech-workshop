# Lab 08 — Backend Testing

## Objective
Protect validation, service behavior, and the real API flow.

## Starting Point
Continue from your Lab 07 backend under `student/starter/backend`.

## Steps
1. Create the xUnit test project.
2. Test valid and invalid task requests.
3. Test create, unknown update, and delete with in-memory SQLite.
4. Add API integration tests for login, CRUD, role restriction, and restart persistence.

## Validation
Run `dotnet test student/starter/backend/WebTechWorkshop.sln`; all seven tests pass.

## Recovery
Compare with `instructor/solutions/backend/TaskApi.Tests/` and run one test class at a time with `--filter`.

## Expected Result
The backend contract is safe for Day 2 integration.
