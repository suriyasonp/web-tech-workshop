using Microsoft.EntityFrameworkCore;
using TaskApi.Contracts;
using TaskApi.Data;
using TaskApi.Models;

namespace TaskApi.Services;

public sealed class TaskService(AppDbContext db)
{
    public async Task<IReadOnlyList<TaskResponse>> GetAllAsync(CancellationToken cancellationToken) =>
        await db.Tasks.AsNoTracking().OrderByDescending(task => task.CreatedAt)
            .Select(task => new TaskResponse(task.Id, task.Title, task.Description, task.Status,
                task.Priority, task.DueDate, task.CreatedAt)).ToListAsync(cancellationToken);

    public async Task<TaskResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var task = await db.Tasks.AsNoTracking().SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        return task is null ? null : TaskResponse.FromEntity(task);
    }

    public async Task<TaskResponse> CreateAsync(TaskRequest request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Title = request.Title!.Trim(), Description = Normalize(request.Description),
            Status = request.Status, Priority = request.Priority, DueDate = request.DueDate
        };
        db.Tasks.Add(task);
        await db.SaveChangesAsync(cancellationToken);
        return TaskResponse.FromEntity(task);
    }

    public async Task<TaskResponse?> UpdateAsync(int id, TaskRequest request, CancellationToken cancellationToken)
    {
        var task = await db.Tasks.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        if (task is null) return null;
        task.Title = request.Title!.Trim();
        task.Description = Normalize(request.Description);
        task.Status = request.Status;
        task.Priority = request.Priority;
        task.DueDate = request.DueDate;
        await db.SaveChangesAsync(cancellationToken);
        return TaskResponse.FromEntity(task);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var task = await db.Tasks.SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        if (task is null) return false;
        db.Tasks.Remove(task);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static string? Normalize(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
