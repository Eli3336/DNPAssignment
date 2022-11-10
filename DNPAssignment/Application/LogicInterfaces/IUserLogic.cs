using Domain.DTOs;
using Domain.Models;


namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
     Task<User> Create(UserCreationDto dto);
     Task<IEnumerable<User>> GetAsync(SearchUserParametersDto? searchParameters);
    

}
