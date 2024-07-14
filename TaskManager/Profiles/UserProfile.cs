using AutoMapper;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Profiles;

public class UserProfile : Profile
{
    /// <summary>
    ///     Mapping for user object.
    /// </summary>
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}
