using Entities.Models;

namespace Domain.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User?> GetByUsername(object userName);
    Task<User> Create(User toCreate);
}