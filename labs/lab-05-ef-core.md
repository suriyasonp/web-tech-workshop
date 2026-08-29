# Lab 05 — EF Core and SQLite

## Objective
Replace temporary memory with persistent storage.

## Starting Point
Checkout `lab-05-start`.

## Steps
1. Add EF Core SQLite and Design packages.
2. Create `TaskItem`, `AppDbContext`, and model configuration.
3. Add the SQLite connection string.
4. Create and apply `InitialCreate` migration.
5. Seed two tasks only when the table is empty.
6. Change `TaskService` to use async EF Core queries.

## Validation
Create a task, restart the API, and confirm the task still appears.

## Recovery
Checkout `lab-05-solution`; if schema state is broken, stop the API and remove only `TaskApi/tasks.db`.

## Expected Result
Task CRUD persists through EF Core and SQLite.
