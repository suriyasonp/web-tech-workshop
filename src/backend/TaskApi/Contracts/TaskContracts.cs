using TaskApi.Models;

namespace TaskApi.Contracts;

public sealed record TaskRequest(string? Title, string? Description, TaskItemStatus Status,
    TaskPriority Priority, DateOnly? DueDate);

public sealed record TaskResponse(int Id, string Title, string? Description, TaskItemStatus Status,
    TaskPriority Priority, DateOnly? DueDate, DateTimeOffset CreatedAt)
{
    public static TaskResponse FromEntity(TaskItem task) => new(task.Id, task.Title, task.Description,
        task.Status, task.Priority, task.DueDate, task.CreatedAt);
}

public static class TaskRequestValidator
{
    public static Dictionary<string, string[]> Validate(TaskRequest request)
    {
        var errors = new Dictionary<string, string[]>();
        if (string.IsNullOrWhiteSpace(request.Title))
            errors[nameof(request.Title)] = ["Title is required."];
        else if (request.Title.Trim().Length > 120)
            errors[nameof(request.Title)] = ["Title must be 120 characters or fewer."];
        if (request.Description?.Length > 1000)
            errors[nameof(request.Description)] = ["Description must be 1000 characters or fewer."];
        if (!Enum.IsDefined(request.Status))
            errors[nameof(request.Status)] = ["Status is invalid."];
        if (!Enum.IsDefined(request.Priority))
            errors[nameof(request.Priority)] = ["Priority is invalid."];
        return errors;
    }
}
