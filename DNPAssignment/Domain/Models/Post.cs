using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public User User { get; private set; }
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    [MinLength(3)]

    public string Title { get; private set; }
    
    [Required]
    [MaxLength(150)]
    [MinLength(3)]

    public string Body { get; private set; }

    public Post(User user, string title, string body)
    {
        User = user;
        Title = title;
        Body = body;
    }
    
    private Post(){}
}