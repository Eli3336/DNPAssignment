using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Domain.Models;

namespace WebApi.Services;

public class AuthLogic:IAuthLogic
{
    private IList<User> users = new List<User>();

    public AuthLogic()
    {
        string content = File.ReadAllText("data.json");
        users = JsonSerializer.Deserialize<List<User>>(content);
    }

    public Task<User> ValidateUser(string username, string password)
    {
       
        string content = File.ReadAllText("data.json");
        users = JsonSerializer.Deserialize<List<User>>(content);
        
        User? existingUser = users.FirstOrDefault(u => 
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
        
        return Task.CompletedTask;
    }
}
