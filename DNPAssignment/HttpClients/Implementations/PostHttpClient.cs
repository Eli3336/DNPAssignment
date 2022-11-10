using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

   /* public async Task<ICollection<Post>> GetAsync(string? userName, string? titleContains)
    {
        HttpResponseMessage response = await client.GetAsync("/Posts");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }*/
   public async Task<ICollection<Post>> GetAsync(string? userName, string? titleContains)
   {
       string query = ConstructQuery(userName, titleContains);

       HttpResponseMessage response = await client.GetAsync("/Posts" + query);
       string content = await response.Content.ReadAsStringAsync();
       if (!response.IsSuccessStatusCode)
       {
           throw new Exception(content);
       }

       ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
       {
           PropertyNameCaseInsensitive = true
       })!;
       return posts;
   }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Posts",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    /*public async Task<Post?> GetByTitleAsync(string title)
    {
        HttpResponseMessage response = await client.GetAsync($"/Posts/{title}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Post post = JsonSerializer.Deserialize<Post?>(content, 
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        )!;
        return post;
    }*/
    
    public async Task<PostBasicDto> GetByTitleAsync(string title)
    {
        HttpResponseMessage response = await client.GetAsync($"/Posts/{title}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        PostBasicDto post = JsonSerializer.Deserialize<PostBasicDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
    

    public async Task<IEnumerable<Post>> GetPosts(string? titleContains = null)
    {
        string uri = "/Posts";
        if (!string.IsNullOrEmpty(titleContains))
        {
            uri += $"?title={titleContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine(result);
        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
    
    private static string ConstructQuery(string? userName,  string? titleContains)
    {
        string query = "";
        if (!string.IsNullOrEmpty(userName))
        {
            query += $"?UserName={userName}";
        }
        

        if (!string.IsNullOrEmpty(titleContains))
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"titleContains={titleContains}";
        }

        return query;
    }
}
