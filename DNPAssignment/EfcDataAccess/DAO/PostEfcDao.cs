using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAO;

public class PostEfcDao : IPostDao
{
    private readonly ForumContext context;

    public PostEfcDao(ForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.User).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters?.Username))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.User.UserName.ToLower().Equals(searchParameters.Username.ToLower()));
        }
    
       
        if (!string.IsNullOrEmpty(searchParameters?.TitleContains))
        {
            query = query.Where(p =>
                p.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByTitleAsync(string title)
    {
        Post? post = await context.Posts.FindAsync(title);
        return post;    
    }
    
//this is SO not working
    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
        IQueryable<Post> query = context.Posts.Include(post => post.User).AsQueryable();
        ICollection<Post> result = new List<Post>();
        foreach (Post post in query)
        {
            result.Add(post);
        }
        return result;
    }
}