namespace Application.DaoInterfaces;

public class IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByUsernameAsync(string title);
}