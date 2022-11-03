namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? TitleContains { get;  }

    public SearchPostParametersDto(string? titleContains)
    {
        TitleContains = titleContains;
    }
}