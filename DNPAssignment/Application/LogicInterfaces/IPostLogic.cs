using Domain.DTOs;

namespace Application.LogicInterfaces;

public class IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto userToCreate);
}