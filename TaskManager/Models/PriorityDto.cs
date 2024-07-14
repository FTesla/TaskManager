using TaskManager.Enums;

namespace TaskManager.Entities;

/// <summary>
///     Priority for tasks.
/// </summary>
public class PriorityDto
{
    /// <summary>
    ///     Priority level for task.
    /// </summary>
    public PriorityLevels Level { get; set; }

}