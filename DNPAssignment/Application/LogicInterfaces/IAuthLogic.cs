﻿using Domain.Models;

public interface IAuthLogic
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}