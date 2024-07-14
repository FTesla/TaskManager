using TaskManager.Entities;

namespace TaskManager.Models;

/// <summary>
///     Transport object to delete a task.
/// </summary>
public class TaskForUpdateDto
{
    /// <summary>
    ///     Task title.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Task description
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    ///     Task done\not done.
    /// </summary>
    public required bool IsCompleted { get; set; }

    /// <summary>
    ///     Task completion date.
    /// </summary>
    public required DateTime DueDate { get; set; }

    /// <summary>
    ///     Priority task.
    /// </summary>
    public required Priority Priority { get; set; }
}