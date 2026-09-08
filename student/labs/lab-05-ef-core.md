# Lab 05 — Persist Tasks with EF Core and SQLite

**Duration:** 60 minutes  
**Goal:** Replace the temporary list with a SQLite database.

## Starting Point

Continue from Lab 04. Stop the API before changing packages or migrations.

## Exercise 1 — Install packages and EF tool

From `student/starter/backend/TaskApi`:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 10.*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.*
dotnet tool install --global dotnet-ef --version 10.*
dotnet ef --version
```

If the tool already exists, run `dotnet tool update --global dotnet-ef --version 10.*`.

## Exercise 2 — Model and configure storage

Create `Models/TaskItem.cs` and `Data/AppDbContext.cs`. Configure required title, maximum lengths 120/1000, status, priority, and due date.

Add to `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=tasks.db"
}
```

Register `AppDbContext` with `UseSqlite` in `Program.cs`. Change `TaskService` to scoped lifetime and async EF queries.

## Exercise 3 — Create and apply the schema

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

Create a task, stop and restart the API, then GET the collection.

## Validation

The new task remains after restart. `Migrations/` and `tasks.db` exist. Do not commit `tasks.db`.

## Recovery

Run EF commands from the folder containing `TaskApi.csproj`. For a broken practice schema, stop the API and delete only `student/starter/backend/TaskApi/tasks.db`, then run `dotnet ef database update`. Compare with `instructor/solutions/backend/`.

## Expected result

CRUD persists through EF Core and SQLite.
