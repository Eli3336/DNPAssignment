using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.UserName);
        if (user == null)
        {
            throw new Exception($"User with id {dto.UserName} was not found.");
        }

        ValidateData(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }
    
    public Task<List<string>> GetAllPostsAsync()
    {
        return postDao.GetAllPostsAsync();
    }

    public async Task<PostBasicDto> GetByTitleAsync(string Title)
    {
        Post? post = await postDao.GetByTitleAsync(Title);
        if (post == null)
        {
            throw new Exception($"Post with title {Title} not found");
        }

        return new PostBasicDto(post.Id, post.User.UserName, post.Title, post.Body);
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