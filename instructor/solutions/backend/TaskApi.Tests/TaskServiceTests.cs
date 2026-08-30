using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskApi.Contracts;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Tests;

public sealed class TaskServiceTests : IAsyncDisposable
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");
    private readonly AppDbContext db;
    private readonly TaskService service;

    public TaskServiceTests()
    {
        connection.Open();
        db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options);
        db.Database.EnsureCreated();
        service = new TaskService(db);
    }

    [Fact]
    public async Task CreateAsync_ValidTask_PersistsTask()
    {
        var created = await service.CreateAsync(
            new TaskRequest("Test the API", null, TaskItemStatus.ToDo, TaskPriority.High, null), CancellationToken.None);
        Assert.True(created.Id > 0);
        Assert.Equal(1, await db.Tasks.CountAsync());
    }

    [Fact]
    public async Task UpdateAsync_UnknownTask_ReturnsNull()
    {
        var result = await service.UpdateAsync(999,
            new TaskRequest("Unknown", null, TaskItemStatus.ToDo, TaskPriority.Low, null), CancellationToken.None);
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ExistingTask_RemovesTask()
    {
        var created = await service.CreateAsync(
            new TaskRequest("Delete me", null, TaskItemStatus.ToDo, TaskPriority.Low, null), CancellationToken.None);
        Assert.True(await service.DeleteAsync(created.Id, CancellationToken.None));
        Assert.Empty(await db.Tasks.ToListAsync());
    }

    public async ValueTask DisposeAsync()
    {
        await db.DisposeAsync();
        await connection.DisposeAsync();
    }
}
