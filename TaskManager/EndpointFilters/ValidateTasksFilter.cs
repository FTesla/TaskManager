using TaskManager.Enums;

namespace TaskManager.EndpointFilters;

/// <summary>
///     Validation of input data for request to receive tasks.
/// </summary>
public class ValidateTasksFilter : IEndpointFilter
{
    /// <summary>
    ///     Method for embedding in middleware.
    /// </summary>
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            var isCompleted = context.GetArgument<bool?>(3);
        }
        catch (Exception e)
        {
            return TypedResults.Problem("isCompleted Error");
        }

        try
        {
            var priority = context.GetArgument<PriorityLevels?>(4);
        }
        catch (Exception e)
        {
            return TypedResults.Problem("priority Error");
        }

        return await next(context);
    }
}
