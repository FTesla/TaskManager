using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Entities;

/// <summary>
///     Tasks.
/// </summary>
public class ToDoItem
{
    /// <summary>
    ///     Task id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    ///     Task title.
    /// </summary>
    [Required]
    public required string Title { get; set; }

    /// <summary>
    ///     Task description
    /// </summary>
    [Required]
    public required string Description { get; set; }

    /// <summary>
    ///     Task done\not done.
    /// </summary>
    [Required]
    public required bool IsCompleted { get; set; }

    /// <summary>
    ///     Task completion date.
    /// </summary>
    [Required]
    public required DateTime DueDate { get; set; }

    /// <summary>
    ///     Priority task.
    /// </summary>
    [Required]
    public required Priority Priority { get; set; }

    /// <summary>
    ///     Performer.
    /// </summary>
    public User? User { get; set; }

    public ToDoItem()
    {
    }

    /// <summary>
    ///     Setting required fields through the constructor.
    /// </summary>
    [SetsRequiredMembers]
    public ToDoItem(Guid id,
                    string title,
                    string description,
                    bool isCompleted,
                    DateTime dueDate,
                    Priority priority) : this(id, title, description, isCompleted, dueDate)
    {
        Priority = priority;
    }

    /// <summary>
    ///     Setting required fields through the constructor.
    /// </summary>
    [SetsRequiredMembers]
    private ToDoItem(Guid id,
        string title,
        string description,
        bool isCompleted,
        DateTime dueDate)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        DueDate = dueDate;
    }
}