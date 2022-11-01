using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface ITodoDao
{
    Task<ToDo> CreateAsync(ToDo todo);
    Task<IEnumerable<ToDo>> GetAsync(SearchTodoParametersDto searchParameters);
    Task UpdateAsync(ToDo todo);
    Task<ToDo> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}