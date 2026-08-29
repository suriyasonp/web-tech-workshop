using TaskApi.Contracts;
using TaskApi.Services;

namespace TaskApi.Endpoints;

public static class TaskEndpoints
{
    public static IEndpointRouteBuilder MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tasks").RequireAuthorization().WithTags("Tasks");

        group.MapGet("/", async (TaskService service, CancellationToken ct) => Results.Ok(await service.GetAllAsync(ct)));
        group.MapGet("/{id:int}", async (int id, TaskService service, CancellationToken ct) =>
        {
            var task = await service.GetByIdAsync(id, ct);
            return task is null ? Results.Problem(title: "Task not found.", statusCode: 404) : Results.Ok(task);
        });
        group.MapPost("/", async (TaskRequest request, TaskService service, CancellationToken ct) =>
        {
            var errors = TaskRequestValidator.Validate(request);
            if (errors.Count > 0) return Results.ValidationProblem(errors);
            var task = await service.CreateAsync(request, ct);
            return Results.Created($"/api/tasks/{task.Id}", task);
        });
        group.MapPut("/{id:int}", async (int id, TaskRequest request, TaskService service, CancellationToken ct) =>
        {
            var errors = TaskRequestValidator.Validate(request);
            if (errors.Count > 0) return Results.ValidationProblem(errors);
            var task = await service.UpdateAsync(id, request, ct);
            return task is null ? Results.Problem(title: "Task not found.", statusCode: 404) : Results.Ok(task);
        });
        group.MapDelete("/{id:int}", async (int id, TaskService service, CancellationToken ct) =>
            await service.DeleteAsync(id, ct) ? Results.NoContent() : Results.Problem(title: "Task not found.", statusCode: 404))
            .RequireAuthorization(policy => policy.RequireRole("Instructor"));
        return app;
    }
}
