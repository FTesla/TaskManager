using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TaskManager.Enums;

namespace TaskManager.Entities;

/// <summary>
///     Priority for tasks.
/// </summary>
public class Priority
{
    /// <summary>
    ///     Priority level for task.
    /// </summary>
    [Key]
    public required PriorityLevels Level { get; set; }

    /// <summary>
    ///     Priority in tasks.
    /// </summary>
    private List<ToDoItem> ToDoItems { get; set; }

    /// <summary>
    ///     Setting required fields through the constructor.
    /// </summary>
    [SetsRequiredMembers]
    public Priority(PriorityLevels level)
    {
        Level = level;
    }
}