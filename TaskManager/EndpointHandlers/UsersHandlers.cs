using AutoMapper;
using TaskManager.DbContexts;
using TaskManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.EndpointHandlers;

/// <summary>
///     Request handlers for users.
/// </summary>
public static class UsersHandlers
{
    /// <summary>
    ///     Request all users.
    /// </summary>
    /// <returns> Returns an array of DTO objects with users. </returns>
    public static async Task<Ok<IEnumerable<UserDto>>> GetUsersAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        ILogger<UserDto> logger)
    {
        return TypedResults.Ok(mapper.Map<IEnumerable<UserDto>>(await dbContext.Users.ToListAsync()));
    }

}
