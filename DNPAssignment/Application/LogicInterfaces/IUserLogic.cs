using Entities.DTOs;
using Entities.Models;

namespace Domain.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
}