using TaskManager.EndpointFilters;
using TaskManager.EndpointHandlers;

namespace TaskManager.Extensions;

/// <summary>
///     Extensions endpoint route builder.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    ///     Task endpoints.
    /// </summary>
    public static void RegisterTaskEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var tasksEndpoints = endpointRouteBuilder.MapGroup("/tasks");
        var tasksWithGuidIdEndpoints = tasksEndpoints.MapGroup("/{taskId:guid}");

        tasksEndpoints.MapGet("", TasksHandlers.GetTasksAsync)
            .AddEndpointFilter<ValidateTasksFilter>()
            .WithName("GetTasks")
            .WithOpenApi()
            .WithSummary("Get tasks.")
            .WithDescription("Optional filters: 'isCompleted' - completed task filter ,'priority' - filter by task priority."); 

        tasksEndpoints.MapPost("", TasksHandlers.CreateTaskAsync)
            .WithName("CreateTask")
            .WithOpenApi()
            .WithSummary("Create task.");

        tasksWithGuidIdEndpoints.MapGet("", TasksHandlers.GetTaskByIdAsync)
            .WithName("GetTaskById")
            .WithOpenApi()
            .WithSummary("Get a task by providing an id.");

        tasksWithGuidIdEndpoints.MapPut("", TasksHandlers.UpdateTaskAsync)
            .WithName("UpdateTask")
            .WithOpenApi()
            .WithSummary("Update task.");

        tasksWithGuidIdEndpoints.MapDelete("", TasksHandlers.DeleteTaskAsync)
            .WithName("DeleteTask")
            .WithOpenApi()
            .WithSummary("Delete task.");

        tasksEndpoints.MapPatch("/{taskId:guid}/{userId:guid}", TasksHandlers.SetUserToTaskAsync)
            .WithName("AssignTaskToUser.")
            .WithOpenApi()
            .WithSummary("Assign a task to a user.");

    }

    /// <summary>
    ///     User endpoints.
    /// </summary>
    public static void RegisterUsersEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var usersEndpoints = endpointRouteBuilder.MapGroup("/users");

        usersEndpoints.MapGet("", UsersHandlers.GetUsersAsync)
            .WithName("GetUsers")
            .WithOpenApi()
            .WithSummary("Get all users on the system.")
            .WithDescription("You can get all users through this endpoint.");

    }
}
