namespace Domain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string UserName { get; }
    public string Title { get; }
    public string Body { get;  }

    public PostBasicDto(int Id, string UserName, string Title, string Body)
    {
        this.Id = Id;
        this.UserName = UserName;
        this.Title = Title;
        this.Body = Body;
    }
}