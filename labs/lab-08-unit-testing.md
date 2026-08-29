# Lab 08 — Backend Testing

## Objective
Protect validation, service behavior, and the real API flow.

## Starting Point
Checkout `lab-08-start`.

## Steps
1. Create the xUnit test project.
2. Test valid and invalid task requests.
3. Test create, unknown update, and delete with in-memory SQLite.
4. Add API integration tests for login, CRUD, role restriction, and restart persistence.

## Validation
Run `dotnet test src/backend/WebTechWorkshop.sln`; all seven tests pass.

## Recovery
Checkout `lab-08-solution` and run one test class at a time with `--filter`.

## Expected Result
The backend contract is safe for Day 2 integration.
