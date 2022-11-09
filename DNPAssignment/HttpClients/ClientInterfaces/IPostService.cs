using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<Post>> GetAsync(
        string? userName,
        string? userID,
        int? id, 
        string? titleContains, 
        string? body
    );
    
}