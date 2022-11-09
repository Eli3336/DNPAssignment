using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public string UserName { get; }
    public string Title { get;}
    public string Body { get; }
    public PostCreationDto(string userName, string title, string body)
    {
        UserName = userName;
        Title = title;
        Body = body;
    }
}