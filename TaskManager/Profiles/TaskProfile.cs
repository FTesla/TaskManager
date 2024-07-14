using AutoMapper;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Profiles;

/// <summary>
///     Mapping for task object.
/// </summary>
public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<ToDoItem, TaskDto>()
            .ForMember(
                u => u.PerformerUser,
                o => o.MapFrom(s => s.User))
            .ForMember(
                p => p.Priority,
                o => o.MapFrom(s => s.Priority));
            
        CreateMap<TaskCreateDto, ToDoItem>();
        CreateMap<TaskForUpdateDto, ToDoItem>();
    }
}
