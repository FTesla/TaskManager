using TaskManager.Entities;

namespace TaskManager.Models;

/// <summary>
///     Transport object to create a task.
/// </summary>
public class TaskCreateDto
{
 /// <summary>
    ///     Task title.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Task description.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    ///     Task completion date.
    /// </summary>
    public required DateTime DueDate { get; set; }

    /// <summary>
    ///     Priority task.
    /// </summary>
    public required Priority Priority { get; set; }
}