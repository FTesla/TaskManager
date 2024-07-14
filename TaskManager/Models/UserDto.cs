using System.ComponentModel.DataAnnotations;
using TaskManager.Entities;

namespace TaskManager.Models;

/// <summary>
///     Transport object user.
/// </summary>
public class UserDto
{
    /// <summary>
    ///     User id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     User name.
    /// </summary>
    public required string Name { get; set; }
}