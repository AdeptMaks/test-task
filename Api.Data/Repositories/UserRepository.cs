using Api.Data.Entities;
using Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<List<BaseUser>> GetList()
    {
        return await context.Users
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<BaseUser?> GetById(Guid id)
    {
        return await context.Users
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task Add(BaseUser entity)
    {
        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        await context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
    }
    public async Task Update(BaseUser entity)
    {
        await context.Users
            .Where(u => u.Id == entity.Id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(p => p.Login, entity.Login)
                .SetProperty(p => p.Password, entity.Password)
            );
    }
    public async Task<BaseUser?> GetByLogin(string login)
    {
        return await context.Users
            .Where(u => u.Login == login)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}
