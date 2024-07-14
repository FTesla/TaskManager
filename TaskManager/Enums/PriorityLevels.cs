using System.ComponentModel;

namespace TaskManager.Enums
{
    /// <summary>
    /// Priority levels for tasks.
    /// </summary>
    public enum PriorityLevels
    {
        /// <summary>
        /// Low priority.
        /// </summary>
        [Description("Low priority task.")]
        Low = 1,

        /// <summary>
        /// Medium priority.
        /// </summary>
        [Description("Medium priority task.")]
        Medium = 2,

        /// <summary>
        /// High priority.
        /// </summary>
        [Description("High priority task.")]
        High = 3
    }
}
