using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskApi.Data;

#nullable disable

namespace TaskApi.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder.HasAnnotation("ProductVersion", "10.0.0");
        modelBuilder.Entity("TaskApi.Models.TaskItem", entity =>
        {
            entity.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property<DateTimeOffset>("CreatedAt").HasColumnType("TEXT");
            entity.Property<string>("Description").HasMaxLength(1000).HasColumnType("TEXT");
            entity.Property<DateOnly?>("DueDate").HasColumnType("TEXT");
            entity.Property<string>("Priority").IsRequired().HasColumnType("TEXT");
            entity.Property<string>("Status").IsRequired().HasColumnType("TEXT");
            entity.Property<string>("Title").IsRequired().HasMaxLength(120).HasColumnType("TEXT");
            entity.HasKey("Id");
            entity.ToTable("Tasks");
        });
#pragma warning restore 612, 618
    }
}
