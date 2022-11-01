using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Application.DaoInterfaces;
using Domain.Models;

namespace Application.Logic;

public class AuthLogic:IAuthLogic
{
    private readonly IUserDao userdao;

    public Task<User> ValidateUser(string username, string password)
    {
      
        List<User> users = userdao.GetAll();
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
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

        if (string.IsNullOrEmpty(user.Username))
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
        
        return Task.CompletedTask;
    }
}