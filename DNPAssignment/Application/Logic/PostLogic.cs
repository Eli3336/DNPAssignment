using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        Post? existing = await postDao.GetByTitleAsync(dto.title);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        Post toCreate = new Post
        {
            Title = dto.title,
            user = dto.user,
            Body = dto.body
        };
    
        Post created = await postDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(PostCreationDto postToCreate)
    {
        string title = postToCreate.title;
        User user = postToCreate.user;
        string body = postToCreate.body;

        if (title.Length < 3)
            throw new Exception("Title must be at least 3 characters!");

        if (title.Length > 50)
            throw new Exception("Title must be less than 50 characters!");

        if ((user.Id<0))
            throw new Exception("User not existing!");
        
        if (title.Length < 3)
            throw new Exception("Body must be at least 3 characters!");

        if (title.Length > 150)
            throw new Exception("Body must be less than 150 characters!");
    }
}