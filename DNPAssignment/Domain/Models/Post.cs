namespace Domain.Models;

public class Post
{
    public User User { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(User user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }
}