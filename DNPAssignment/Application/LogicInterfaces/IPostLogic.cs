using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto postToCreate);
    
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto? searchParameters);
    
    Task<List<string>> GetAllPostsAsync();
    Task<PostBasicDto> GetByTitleAsync(string Title);

}