# Lab 04 — Build Task CRUD Endpoints

**Duration:** 60 minutes  
**Goal:** Implement the REST create, read, update, and delete flow before adding a database.

## Starting point

Continue from Lab 03 in `student/starter/backend/TaskApi`.

## Exercise 1 — Add request DTOs and service

Create `Contracts/CreateTaskRequest.cs` and `UpdateTaskRequest.cs` with title, description, status, priority, and optional due date. Create `Services/TaskService.cs` using a private `List<TaskResponse>` and an incrementing ID.

Implement methods: `GetAll`, `GetById`, `Create`, `Update`, and `Delete`. Register it in `Program.cs`:

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

For POST use `Results.Created($"/api/tasks/{created.Id}", created)`.

## Exercise 3 — Run the complete flow

Add requests to `TaskApi.http` in this order: POST, GET by returned ID, PUT, GET collection, DELETE, GET deleted ID. Separate requests with `###`.

## Check your work

Create → read → update → delete succeeds. The final GET returns 404. POST returns 201 and a `Location` header.

## Troubleshooting / instructor recovery

If data disappears when restarting, that is expected in this lab. Trace endpoint → service → list. Compare only matching route and service methods with `instructor/solutions/backend/`.

## Expected result

A complete REST-shaped API with behavior separated from route definitions.
