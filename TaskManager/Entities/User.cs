using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Entities;

/// <summary>
///     User in system.
/// </summary>
public class User
{
    /// <summary>
    ///     User id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    ///     User name.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    ///     Tasks for user.
    /// </summary>
    public List<ToDoItem> ToDoItems { get; set; }

    /// <summary>
    ///     Setting required fields through the constructor.
    /// </summary>
    [SetsRequiredMembers]
    public User(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

