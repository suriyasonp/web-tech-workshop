# Backend — Task Management API

Runnable .NET 10 Minimal API with EF Core, SQLite, JWT authentication, role-aware authorization, validation, and tests.

## Run

```bash
cd instructor/solutions/backend
dotnet restore
dotnet run --project TaskApi
```

The API listens on `http://localhost:5080`. OpenAPI JSON is available at `http://localhost:5080/openapi/v1.json` in Development.

| Username | Password | Permission |
|---|---|---|
| `instructor` | `Workshop2026!` | Full CRUD |
| `student` | `Workshop2026!` | CRUD except delete |

These accounts and the JWT key are intentionally simple for local workshop use only.

## Test

```bash
dotnet test
```

SQLite is created as `instructor/solutions/backend/TaskApi/tasks.db` on first run and seeded with two tasks.
