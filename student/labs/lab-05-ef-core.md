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

Create `Models/TaskItem.cs`:

```csharp
namespace TaskApi.Models;

public sealed class TaskItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "Todo";
    public string Priority { get; set; } = "Medium";
    public DateOnly? DueDate { get; set; }
}
```

Create `Data/AppDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.Property(x => x.Title).IsRequired().HasMaxLength(120);
            entity.Property(x => x.Description).HasMaxLength(1000);
            entity.Property(x => x.Status).HasMaxLength(30);
            entity.Property(x => x.Priority).HasMaxLength(30);
        });
    }
}
```

Add to `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

Register EF Core in `Program.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TaskService>();
```

Change `TaskService` methods to async EF queries such as:

```csharp
public async Task<List<TaskItem>> GetAllAsync(CancellationToken ct) =>
    await _db.Tasks.AsNoTracking().OrderBy(x => x.Id).ToListAsync(ct);
```

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
