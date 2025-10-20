namespace Api.Domain.Models.DTOs;

public record URLCreateRequest(string OriginalURL, string? CustomAlias = null);