

using System.ComponentModel.DataAnnotations;
using Domain.Models;
using FileData;

namespace WebApi.Services;


public class AuthService:IAuthService
{

    public FileContext context;
    
    private readonly IList<User> users = new List<User>
    {
        new User
        {
            UserName = "Ana",
            Password = "banana"
        },
        new User
        {
            UserName="Bob",
            Password = "password"
        }
    };
    public Task<User> ValidateUser(string username, string password)
    {

        User? existingUser = context.Users.FirstOrDefault(u => 
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        context.Users.Add(user);
        return Task.CompletedTask;
    }
}
