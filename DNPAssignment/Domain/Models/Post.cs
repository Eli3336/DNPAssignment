namespace Domain.Models;

public class Post
{
    public User User { get; private set; }
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Body { get; private set; }

    public Post(User user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }
    
    private Post(){}
}