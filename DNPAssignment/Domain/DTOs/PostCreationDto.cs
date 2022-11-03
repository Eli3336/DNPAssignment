using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public string title { get;}
    public User user { get; }
    public string body { get; }
    public PostCreationDto(string title, User user, string body)
    {
        this.title = title;
        this.user = user;
        this.body = body;
    }
}