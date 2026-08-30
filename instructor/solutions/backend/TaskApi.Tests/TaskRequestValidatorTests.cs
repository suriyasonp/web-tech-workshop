using TaskApi.Contracts;
using TaskApi.Models;

namespace TaskApi.Tests;

public sealed class TaskRequestValidatorTests
{
    [Fact]
    public void Validate_MissingTitle_ReturnsTitleError()
    {
        var request = new TaskRequest("  ", null, TaskItemStatus.ToDo, TaskPriority.Medium, null);
        var errors = TaskRequestValidator.Validate(request);
        Assert.Contains("Title", errors.Keys);
    }

    [Fact]
    public void Validate_ValidRequest_ReturnsNoErrors()
    {
        var request = new TaskRequest("Learn Minimal APIs", "Workshop task",
            TaskItemStatus.InProgress, TaskPriority.High, new DateOnly(2026, 9, 13));
        Assert.Empty(TaskRequestValidator.Validate(request));
    }
}
