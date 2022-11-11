using Domain.DTOs;
using Domain.Models;

namespace BlazorApp.Services.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
}