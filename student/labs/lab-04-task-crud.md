# Lab 04 — Build Task CRUD Endpoints

**Duration:** 60 minutes  
**Goal:** Implement the REST create, read, update, and delete flow before adding a database.

## Starting Point

Continue from Lab 03 in `student/starter/backend/TaskApi`.

## Exercise 1 — Add request DTOs and service

Create `Contracts/CreateTaskRequest.cs` and `UpdateTaskRequest.cs` with title, description, status, priority, and optional due date. Create `Services/TaskService.cs` using a private `List<TaskResponse>` and an incrementing ID.

Example request DTO:

```csharp
namespace TaskApi.Contracts;

public sealed record CreateTaskRequest(
    string Title,
    string? Description,
    string Status,
    string Priority,
    DateOnly? DueDate);
```

A minimal in-memory service can start like this:

```csharp
using TaskApi.Contracts;

namespace TaskApi.Services;

public sealed class TaskService
{
    private readonly List<TaskResponse> _tasks = [];
    private int _nextId = 1;

    public IReadOnlyList<TaskResponse> GetAll() => _tasks;

    public TaskResponse? GetById(int id) =>
        _tasks.FirstOrDefault(task => task.Id == id);

    public TaskResponse Create(CreateTaskRequest request)
    {
        var task = new TaskResponse(
            _nextId++, request.Title, request.Description,
            request.Status, request.Priority, request.DueDate);

        _tasks.Add(task);
        return task;
    }
}
```

Add `Update` and `Delete` using the same list. Register the service in `Program.cs`:

```csharp
builder.Services.AddSingleton<TaskService>();
```

## Exercise 2 — Map REST routes

Map these routes, preferably in `Endpoints/TaskEndpoints.cs`:

| Method | Route | Success |
|---|---|---|
| GET | `/api/tasks` | 200 |
| GET | `/api/tasks/{id:int}` | 200 or 404 |
| POST | `/api/tasks` | 201 + Location |
| PUT | `/api/tasks/{id:int}` | 200 or 404 |
| DELETE | `/api/tasks/{id:int}` | 204 or 404 |

Example endpoint group:

```csharp
var tasks = app.MapGroup("/api/tasks");

tasks.MapGet("/", (TaskService service) =>
    Results.Ok(service.GetAll()));

tasks.MapGet("/{id:int}", (int id, TaskService service) =>
    service.GetById(id) is { } task
        ? Results.Ok(task)
        : Results.NotFound());

tasks.MapPost("/", (CreateTaskRequest request, TaskService service) =>
{
    var created = service.Create(request);
    return Results.Created($"/api/tasks/{created.Id}", created);
});
```

Add PUT and DELETE following the same pattern.

## Exercise 3 — Run the complete flow

Add requests to `TaskApi.http` in this order: POST, GET by returned ID, PUT, GET collection, DELETE, GET deleted ID. Separate requests with `###`.

```http
@host = http://localhost:5080

POST {{host}}/api/tasks
Content-Type: application/json

{
  "title": "Finish Lab 04",
  "description": "Build CRUD endpoints",
  "status": "Todo",
  "priority": "High",
  "dueDate": "2026-09-12"
}

###
GET {{host}}/api/tasks
```

## Validation

Create → read → update → delete succeeds. The final GET returns 404. POST returns 201 and a `Location` header.

## Recovery

If data disappears when restarting, that is expected in this lab. Trace endpoint → service → list. Compare only matching route and service methods with `instructor/solutions/backend/`.

## Expected result

A complete REST-shaped API with behavior separated from route definitions.
