using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet("{title}")]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? title)
    {
        try
        {
            SearchPostParametersDto parameters = new(title);
            IEnumerable<Post> posts = await postLogic.GetAsync(parameters);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAllPostsAsync()
    {
        try
        {
            List<string> posts = await postLogic.GetAllPostsAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{Title}")]
    public async Task<ActionResult<PostCreationDto>> GetByTitle([FromRoute] string Title)
    {
        try
        {
            PostBasicDto result = await postLogic.GetByTitleAsync(Title);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}