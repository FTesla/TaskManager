using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;

namespace TaskManager.DbContexts;

/// <summary>
///     The database context for the TaskManager application.
/// </summary>
public class TaskManagerDbContext : DbContext
{
    /// <summary>
    ///     Task.
    /// </summary>
    public DbSet<ToDoItem> Tasks { get; set; }

    /// <summary>
    ///     Priority.
    /// </summary>
    public DbSet<Priority> Priorities { get; set; }

    /// <summary>
    ///     User in system.
    /// </summary>
    public DbSet<User> Users { get; set; }

    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
    }
}
