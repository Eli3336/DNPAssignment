using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByTitleAsync(string title);
    
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters);
    
    public Task<IEnumerable<Post>> GetAllPostsAsync();


}