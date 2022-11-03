using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public string Title { get;}

    public string Body { get; }

    public PostCreationDto(string title, string body)
    {
        Title = title;
        Body = body;
    }
}