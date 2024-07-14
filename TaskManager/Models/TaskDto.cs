using TaskManager.Entities;

namespace TaskManager.Models;

/// <summary>
///     Transport object task.
/// </summary>
public class TaskDto
{
    /// <summary>
    ///     Task id.
    /// </summary>
    public Guid Id { get; set; }

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
    public required PriorityDto Priority { get; set; }

    /// <summary>
    ///     Performer.
    /// </summary>
    public UserDto? PerformerUser { get; set; }
}