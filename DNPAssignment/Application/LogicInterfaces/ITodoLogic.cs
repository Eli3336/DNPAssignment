using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ITodoLogic
{
    Task<ToDo> CreateAsync(TodoCreationDto dto);
    Task<IEnumerable<ToDo>> GetAsync(SearchTodoParametersDto searchParameters);
    Task UpdateAsync(TodoUpdateDto todo);
    Task DeleteAsync(int id);
}