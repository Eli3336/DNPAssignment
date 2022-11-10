using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters);
    Task<Post?> GetByTitleAsync(string Title); 
    Task<List<string>> GetAllPostsAsync();
    


}