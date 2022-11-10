using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<Post>> GetAsync(
        string? userName,
        string? titleContains
    );

    Task CreateAsync(PostCreationDto dto);
    
    Task<PostBasicDto> GetByTitleAsync(string title);

    Task<IEnumerable<Post>> GetPosts(string? titleContains = null);
}