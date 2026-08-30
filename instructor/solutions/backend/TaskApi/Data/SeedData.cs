using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public static class SeedData
{
    public static async Task InitializeAsync(AppDbContext db)
    {
        if (await db.Tasks.AnyAsync()) return;
        db.Tasks.AddRange(
            new TaskItem { Title = "Explore the workshop repository", Description = "Read the agenda and architecture before starting the labs.", Status = TaskItemStatus.Done, Priority = TaskPriority.Medium },
            new TaskItem { Title = "Build the first full-stack feature", Description = "Connect the Vue task list to the Minimal API.", Status = TaskItemStatus.InProgress, Priority = TaskPriority.High, DueDate = new DateOnly(2026, 9, 13) });
        await db.SaveChangesAsync();
    }
}
