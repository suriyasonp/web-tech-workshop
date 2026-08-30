using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using TaskApi.Contracts;
using TaskApi.Models;

namespace TaskApi.Tests;

public sealed class ApiIntegrationTests
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    [Fact]
    public async Task Instructor_CanCompleteCrud_AndDataPersistsAcrossRestart()
    {
        var databasePath = Path.Combine(Path.GetTempPath(), $"workshop-{Guid.NewGuid():N}.db");
        try
        {
            int createdId;
            await using (var factory = CreateFactory(databasePath))
            {
                using var client = factory.CreateClient();
                await SignInAsync(client, "instructor");

                var createResponse = await client.PostAsJsonAsync("/api/tasks",
                    new TaskRequest("Integration test task", "Created by the API test",
                        TaskItemStatus.ToDo, TaskPriority.High, new DateOnly(2026, 9, 13)));
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
                var created = await createResponse.Content.ReadFromJsonAsync<TaskResponse>(JsonOptions);
                Assert.NotNull(created);
                createdId = created.Id;

                var updateResponse = await client.PutAsJsonAsync($"/api/tasks/{createdId}",
                    new TaskRequest(created.Title, created.Description,
                        TaskItemStatus.Done, TaskPriority.Medium, created.DueDate));
                updateResponse.EnsureSuccessStatusCode();
                var updated = await updateResponse.Content.ReadFromJsonAsync<TaskResponse>(JsonOptions);
                Assert.Equal(TaskItemStatus.Done, updated?.Status);
            }

            await using (var restartedFactory = CreateFactory(databasePath))
            {
                using var client = restartedFactory.CreateClient();
                await SignInAsync(client, "instructor");

                var tasks = await client.GetFromJsonAsync<List<TaskResponse>>("/api/tasks", JsonOptions);
                Assert.Contains(tasks!, task => task.Id == createdId && task.Status == TaskItemStatus.Done);

                var deleteResponse = await client.DeleteAsync($"/api/tasks/{createdId}");
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            }
        }
        finally
        {
            if (File.Exists(databasePath)) File.Delete(databasePath);
            if (File.Exists(databasePath + "-shm")) File.Delete(databasePath + "-shm");
            if (File.Exists(databasePath + "-wal")) File.Delete(databasePath + "-wal");
        }
    }

    [Fact]
    public async Task Student_CannotDeleteTask()
    {
        var databasePath = Path.Combine(Path.GetTempPath(), $"workshop-{Guid.NewGuid():N}.db");
        try
        {
            await using var factory = CreateFactory(databasePath);
            using var client = factory.CreateClient();
            await SignInAsync(client, "student");
            var response = await client.DeleteAsync("/api/tasks/1");
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
        finally
        {
            if (File.Exists(databasePath)) File.Delete(databasePath);
        }
    }

    private static WebApplicationFactory<Program> CreateFactory(string databasePath) =>
        new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureAppConfiguration((_, configuration) => configuration.AddInMemoryCollection(
                new Dictionary<string, string?>
                {
                    ["ConnectionStrings:DefaultConnection"] = $"Data Source={databasePath}"
                }));
        });

    private static async Task SignInAsync(HttpClient client, string username)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login",
            new LoginRequest(username, "Workshop2026!"));
        response.EnsureSuccessStatusCode();
        var login = await response.Content.ReadFromJsonAsync<LoginResponse>();
        Assert.NotNull(login);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", login.Token);
    }
}
