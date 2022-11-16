﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Services.ClientInterfaces;
using BlazorApp.Services.Http;
using Domain.DTOs;
using Domain.Models;


namespace BlazorApp.Services.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

  
   public async Task<ICollection<Post>> GetAsync(string? userName, string? titleContains)
   {
       try
       {

           client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
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
       catch (Exception e)
       {
           Console.WriteLine(e.Message);
           return null;
       }
   }

    public async Task CreateAsync(PostCreationDto dto)
    {
        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/Posts", dto);
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    
    
    public async Task<PostCreationDto> GetByTitleAsync(string Title)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        HttpResponseMessage response = await client.GetAsync($"/Posts/{Title}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        PostCreationDto post = JsonSerializer.Deserialize<PostCreationDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
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
