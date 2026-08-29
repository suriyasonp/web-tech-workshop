using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.Property(task => task.Title).HasMaxLength(120).IsRequired();
            entity.Property(task => task.Description).HasMaxLength(1000);
            entity.Property(task => task.Status).HasConversion<string>();
            entity.Property(task => task.Priority).HasConversion<string>();
        });
    }
}
