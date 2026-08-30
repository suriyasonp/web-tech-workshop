using TaskApi.Contracts;
using TaskApi.Services;

namespace TaskApi.Endpoints;

public static class AuthEndpoints
{
    private static readonly Dictionary<string, (string Password, string Role)> DemoUsers =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["student"] = ("Workshop2026!", "Student"),
            ["instructor"] = ("Workshop2026!", "Instructor")
        };

    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", (LoginRequest request, TokenService tokens) =>
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return Results.ValidationProblem(new Dictionary<string, string[]> { ["credentials"] = ["Username and password are required."] });
            if (!DemoUsers.TryGetValue(request.Username, out var user) || user.Password != request.Password)
                return Results.Problem(title: "Invalid username or password.", statusCode: 401);
            return Results.Ok(tokens.Create(request.Username, user.Role));
        }).AllowAnonymous().WithTags("Authentication");
        return app;
    }
}
