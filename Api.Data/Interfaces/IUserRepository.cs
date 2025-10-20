using Api.Data.Entities;

namespace Api.Data.Interfaces;

public interface IUserRepository
{
    Task<List<BaseUser>> GetList();
    Task<BaseUser?> GetById(Guid id);
    Task Add(BaseUser entity);
    Task Delete(Guid id);
    Task Update(BaseUser entity);
    Task<BaseUser?> GetByLogin(string login);
}
