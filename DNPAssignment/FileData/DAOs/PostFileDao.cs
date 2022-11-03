using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<Post?> GetByTitleAsync(string title)
    {
        Post? existing = context.Posts.FirstOrDefault(p =>
            p.Title.Equals(title, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (searchParameters.TitleContains != null)
        {
            posts = context.Posts.Where(p =>
                p.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(posts);
    }
    
    
    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        

        return Task.FromResult(posts);
    }
    
}