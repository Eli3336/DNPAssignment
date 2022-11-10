using Domain.DTOs;
using Domain.Models;

namespace BlazorApp.Services.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
  //  Task<string> GetUserLoggedin();
}