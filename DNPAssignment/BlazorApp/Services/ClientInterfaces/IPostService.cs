﻿using Domain.DTOs;
using Domain.Models;

namespace BlazorApp.Services.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<Post>> GetAsync(string? userName, string? titleContains);

    Task CreateAsync(PostCreationDto dto);
    
    Task<PostCreationDto> GetByTitleAsync(string title);

}