using Api.Data;
using Api.Data.Entities;
using Api.Data.Interfaces;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using Api.Domain.Models.Utils;
using AutoMapper;


namespace Api.Services;

public class URLService(
    IURLRepository repository,
    IMapper mapper,
    IURLShortener urlShortener,
    ILogger<URLService> logger) : IURLService
{
    public async Task<Response<URL>> ShortenURLAsync(URLCreateRequest request, string userId)
    {
        var errors = new Dictionary<string, string[]>();
        if (!Guid.TryParse(userId, out var userGuid))
        {
            logger.LogWarning("Invalid UserId format: {UserId}", userId);
            errors.Add("UserId", ["Invalid UserId format"]);
            return Response<URL>.Failure(errors);
        }
        var shortCode = urlShortener.Shorten(request.OriginalURL);
        var urlEntity = new URLEntity
        {
            OriginalURL = request.OriginalURL,
            ShortenedURL = shortCode,
            CreatedAt = DateTime.UtcNow,
            UserId = userGuid
        };
        await repository.Add(urlEntity);
        var urlResponse = mapper.Map<URL>(urlEntity);
        return Response<URL>.Success(urlResponse);
    }

    public async Task<Response<List<URLShortResponse>>> GetAllURLsAsync(string userId)
    {
        var errors = new Dictionary<string, string[]>();
        if (Guid.TryParse(userId, out var userGuid))
        {
            logger.LogWarning("Invalid UserId format: {UserId}", userId);
            errors.Add("UserId", ["Invalid UserId format"]);
            return Response<List<URLShortResponse>>.Failure(errors);
        }
        var urlEntities = await repository.GetList();
        var responseUrls = urlEntities
            .Where(u => u.UserId == userGuid)
            .Select(u => mapper.Map<URLShortResponse>(u)).ToList();
        
        return Response<List<URLShortResponse>>.Success(responseUrls);
    }
}