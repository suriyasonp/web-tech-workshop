# Lab 08 — Test the Backend

**Duration:** 55 minutes  
**Goal:** Protect validation, service behavior, authentication, and CRUD with repeatable tests.

## Starting Point

Continue from Lab 07 in `student/starter/backend`.

## Exercise 1 — Create the solution and test project

```bash
dotnet new sln -n WebTechWorkshop
dotnet sln WebTechWorkshop.sln add TaskApi/TaskApi.csproj
dotnet new xunit -n TaskApi.Tests --framework net10.0
dotnet sln WebTechWorkshop.sln add TaskApi.Tests/TaskApi.Tests.csproj
dotnet add TaskApi.Tests/TaskApi.Tests.csproj reference TaskApi/TaskApi.csproj
dotnet add TaskApi.Tests package Microsoft.AspNetCore.Mvc.Testing --version 10.*
dotnet add TaskApi.Tests package Microsoft.EntityFrameworkCore.Sqlite --version 10.*
```

## Exercise 2 — Add focused tests

Add validator tests for a valid request and blank title. Add service tests using an **open in-memory SQLite connection** for create, missing update, and delete. Keep each test Arrange → Act → Assert.

## Exercise 3 — Add API integration tests

Use `WebApplicationFactory<Program>`. Make `Program` visible to tests with `public partial class Program { }`. Test login, authenticated CRUD, Student delete restriction, and persistence across a new scope.

## Exercise 4 — Run and diagnose

```bash
dotnet test WebTechWorkshop.sln
dotnet test WebTechWorkshop.sln --filter FullyQualifiedName~Validation
```

## Validation

All seven workshop tests pass. A deliberately broken assertion fails with a useful test name; undo it and rerun.

## Recovery

Keep the SQLite in-memory connection open for the test lifetime. Compare with `instructor/solutions/backend/TaskApi.Tests/` and run one class using `--filter`.

## Expected result

The backend contract is test-backed and safe for frontend integration.
