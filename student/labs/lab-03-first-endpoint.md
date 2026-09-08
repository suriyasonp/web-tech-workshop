# Lab 03 — Return Typed Task Data

**Duration:** 35 minutes  
**Goal:** Connect `GET /api/tasks` to a typed response.

## Starting point

Continue in `student/starter/backend/TaskApi` from Lab 02.

## Exercise 1 — Define the contract

Create folders `Models` and `Contracts`. Add `Models/TaskItemStatus.cs` with values `Todo`, `InProgress`, `Done`; add `Models/TaskPriority.cs` with `Low`, `Medium`, `High`.

Create `Contracts/TaskResponse.cs`:

```csharp
namespace TaskApi.Contracts;

public sealed record TaskResponse(
    int Id, string Title, string? Description,
    string Status, string Priority, DateOnly? DueDate);
```

## Exercise 2 — Map the collection route

In `Program.cs`, create two sample `TaskResponse` values and map:

```csharp
app.MapGet("/api/tasks", () => Results.Ok(sampleTasks))
   .WithName("GetTasks");
```

Keep route names unique. Restart the API after editing.

## Exercise 3 — Inspect the HTTP contract

Create or edit `TaskApi.http`:

```http
@host = http://localhost:5080

GET {{host}}/api/tasks
Accept: application/json
```

Use **Send Request** in VS Code REST Client, or use `curl http://localhost:5080/api/tasks`.

## Check your work

Response is 200 and contains a JSON array. Each object contains camel-case `title`, `status`, and `priority`.

## Think about it

Why return a DTO instead of exposing a database entity? The API contract can remain stable while storage changes.

## Troubleshooting / instructor recovery

Build first with `dotnet build`. Compare the contract with `docs/architecture.md` and only the relevant files in `instructor/solutions/backend/`.

## Expected result

You can identify the route, DTO, serialization, and HTTP response.
