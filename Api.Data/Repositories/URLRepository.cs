using Api.Data.Entities;
using Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class URLRepository(ApplicationDbContext context) : IURLRepository
{
    public async Task Add(URLEntity urlEntity)
    {
        await context.URLs.AddAsync(urlEntity);
        await context.SaveChangesAsync();

    }
    public async Task<URLEntity?> GetByShortenedURLAsync(string shortenedURL)
    {
        return await context.URLs
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.ShortenedURL == shortenedURL);
    }
    public async Task Delete(Guid id)
    {
        await context.URLs
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
    }
    public async Task<List<URLEntity>> GetList()
    {
        return await context.URLs
            .AsNoTracking()
            .ToListAsync();
    }
}