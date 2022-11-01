namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }


    public User(int iD, string userName, string password)
    {
        Id = iD;
        UserName = userName;
        Password = password;

    }
}