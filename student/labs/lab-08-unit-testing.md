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

A validator test:

```csharp
[Fact]
public void Blank_title_is_invalid()
{
    var request = new TaskRequest(
        "  ", null, TaskItemStatus.ToDo, TaskPriority.Medium, null);

    var errors = TaskRequestValidator.Validate(request);

    Assert.Contains("Title", errors.Keys);
}
```

A service test should use an open SQLite in-memory connection:

```csharp
var connection = new SqliteConnection("DataSource=:memory:");
await connection.OpenAsync();

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite(connection)
    .Options;

await using var db = new AppDbContext(options);
await db.Database.EnsureCreatedAsync();
```

Keep each test Arrange → Act → Assert.

## Exercise 3 — Add API integration tests

Make `Program` visible to tests:

```csharp
public partial class Program { }
```

Create a factory-based test:

```csharp
public sealed class ApiIntegrationTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Anonymous_task_request_is_unauthorized()
    {
        var response = await _client.GetAsync("/api/tasks");
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
```

Add tests for login, authenticated CRUD, Student delete restriction, and persistence across a new scope.

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
