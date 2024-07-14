using AutoMapper;
using TaskManager.DbContexts;
using TaskManager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Enums;

namespace TaskManager.EndpointHandlers;

/// <summary>
///     Request handlers for tasks.
/// </summary>
public static class TasksHandlers
{
    /// <summary>
    ///     Request all tasks.
    /// </summary>
    /// <param name="isCompleted"> Completed task filter. </param>
    /// <param name="priority"> Filter by task priority. </param>
    /// <returns> Returns an array of DTO objects with tasks. </returns>
    public static async Task<Ok<IEnumerable<TaskDto>>> GetTasksAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        ILogger<TaskDto> logger,
            [FromQuery] bool? isCompleted,
            [FromQuery] PriorityLevels? priority)
    {
        IQueryable<ToDoItem> tasks = dbContext.Tasks
            .Include(t => t.User)
            .Include(t => t.Priority);

        if(isCompleted != null)
            tasks = tasks.Where(t => t.IsCompleted == isCompleted);

        if (priority != null)
            tasks = tasks.Where(t => t.Priority.Level == priority);

        var tasksResult = await tasks.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<TaskDto>>(tasksResult));
    }

    /// <summary>
    ///     Create task.
    /// </summary>
    public static async Task<Results<NotFound, CreatedAtRoute<TaskDto>>> CreateTaskAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        ILogger<TaskDto> logger,
        TaskCreateDto taskForCreateDto)
    {
        var priority = await dbContext.Priorities.FirstOrDefaultAsync(p => p == taskForCreateDto.Priority);
        if (priority == null)
        {
            return TypedResults.NotFound();
        }

        var taskEntity = mapper.Map<ToDoItem>(taskForCreateDto);
        taskEntity.Priority = priority;
        dbContext.Tasks.Add(taskEntity);
        await dbContext.SaveChangesAsync();

        var taskToReturn = mapper.Map<TaskDto>(taskEntity);

        return TypedResults.CreatedAtRoute(
            taskToReturn,
            "GetTask",
            new
            {
                taskId = taskToReturn.Id
            });
    }

    /// <summary>
    ///     Get task by ID.
    /// </summary>
    public static async Task<Results<NotFound, Ok<TaskDto>>> GetTaskByIdAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        Guid taskId)
    {
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(d => d.Id == taskId);
        if (taskEntity == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(mapper.Map<TaskDto>(taskEntity));
    }

    /// <summary>
    ///     Update task by ID.
    /// </summary>
    public static async Task<Results<NotFound, NoContent>> UpdateTaskAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        Guid taskId,
        TaskForUpdateDto taskForUpdateDto)
    {
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(d => d.Id == taskId);
        if (taskEntity == null)
        {
            return TypedResults.NotFound();
        }

        var priority = await dbContext.Priorities.FirstOrDefaultAsync(p => p == taskForUpdateDto.Priority);
        if (priority == null)
        {
            return TypedResults.NotFound();
        }

        mapper.Map(taskForUpdateDto, taskEntity);
        taskEntity.Priority = priority;
        await dbContext.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    /// <summary>
    ///     Delete task by ID.
    /// </summary>
    public static async Task<Results<NotFound, NoContent>> DeleteTaskAsync(
        TaskManagerDbContext dbContext,
        Guid taskId)
    {
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(d => d.Id == taskId);
        if (taskEntity == null)
        {
            return TypedResults.NotFound();
        }

        dbContext.Tasks.Remove(taskEntity);
        await dbContext.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    /// <summary>
    ///     Assign a task to a user.
    /// </summary>
    public static async Task<Results<NotFound, NoContent>> SetUserToTaskAsync(
        TaskManagerDbContext dbContext,
        IMapper mapper,
        Guid taskId,
        Guid userId)
    {
        var taskEntity = await dbContext.Tasks.FirstOrDefaultAsync(d => d.Id == taskId);
        if (taskEntity == null)
        {
            return TypedResults.NotFound();
        }

        var userEntity = await dbContext.Users.FirstOrDefaultAsync(d => d.Id == userId);
        if (userEntity == null)
        {
            return TypedResults.NotFound();
        }

        taskEntity.User = userEntity;

        await dbContext.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
