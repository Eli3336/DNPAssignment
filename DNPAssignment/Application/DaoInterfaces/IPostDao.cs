using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByTitleAsync(string title);
    
     Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters);
    
     Task<List<string>> GetAllPostsAsync();


}