using Api.Data.Entities;

namespace Api.Data.Interfaces;

public interface IURLRepository
{
    Task Add(URLEntity urlEntity);
    Task<URLEntity?> GetByShortenedURLAsync(string shortenedURL);
    Task Delete(Guid id);
    Task<List<URLEntity>> GetList();
}