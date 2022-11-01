using Domain.DaoInterfaces;
using Entities.Models;
using FileData;

public class UserFileDAO : IUserDao
{
    private readonly FileContext context;

    public UserFileDAO(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<User?> GetByUsername(object userName)
    {
        throw new NotImplementedException();
    }

    public Task<User> Create(User toCreate)
    {
        throw new NotImplementedException();
    }
}