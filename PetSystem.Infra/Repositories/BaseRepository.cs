using Microsoft.EntityFrameworkCore;
using PetSystem.Core.Interfaces.Repositories;
using PetSystem.Infra.Data;

namespace PetSystem.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly PersistContext Db;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(PersistContext context)
    {
        Db = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task Insert(T entity)
    {
        await _dbSet.AddAsync(entity);
        await Db.SaveChangesAsync();
    }

    public virtual async Task Update(T entity)
    {
        await Task.FromResult(Db.Update(entity));
        await Db.SaveChangesAsync();
    }

    public virtual async Task Delete(T entity)
    {
        await Task.FromResult(Db.Remove(entity));
        await Db.SaveChangesAsync();
    }

    public virtual async Task DeleteList(ICollection<T> entity)
    {
        _dbSet.RemoveRange(entity);
        await Db.SaveChangesAsync();
        await Task.CompletedTask;
    }
}