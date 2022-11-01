using Domain.DaoInterfaces;
using Domain.LogicInterfaces;
using Entities.DTOs;
using Entities.Models;

namespace Domain.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUsernameAsync(userToCreate.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(userToCreate);
        User toCreate = new User
        {
            UserName = userToCreate.UserName,
            Password = userToCreate.Password
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        
        if (password.Length < 5)
            throw new Exception("Length must be at least 5 characters!");

        if (password.Length > 15)
            throw new Exception("Length must be less than 16 characters!");
        
    }
}