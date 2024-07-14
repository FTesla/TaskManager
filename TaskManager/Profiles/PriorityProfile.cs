using AutoMapper;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Profiles;

/// <summary>
///     Mapping for priority object.
/// </summary>
public class PriorityProfile : Profile
{
    public PriorityProfile()
    {
        CreateMap<Priority, PriorityDto>();
    }
}
