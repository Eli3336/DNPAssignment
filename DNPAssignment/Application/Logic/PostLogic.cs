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
        Post? existing = await postDao.GetByTitleAsync(dto.Title);
        if (existing != null)
            throw new Exception("Title already taken!");

        ValidateData(dto);
        Post toCreate = new Post
        {
            Title = dto.Title,
            Body = dto.Body
        };
    
        Post created = await postDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(PostCreationDto postToCreate)
    {
        string title = postToCreate.Title;
        string body = postToCreate.Body;

        if (title.Length < 3)
            throw new Exception("Title must be at least 3 characters!");

        if (title.Length > 50)
            throw new Exception("Title must be less than 50 characters!");

        if (body.Length < 3)
            throw new Exception("Body must be at least 3 characters!");

        if (body.Length > 150)
            throw new Exception("Body must be less than 150 characters!");
    }
}