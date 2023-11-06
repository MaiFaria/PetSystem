using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Infra.Data;

namespace PetSystem.Infra.ReadOnly;

public class BaseReadOnly<T> : IBaseReadOnly<T> where T : class
{
    protected readonly PersistContext Db;
    protected readonly DbSet<T> _dbSet;
    protected readonly IMapper _mapper;

    public BaseReadOnly(PersistContext context,
                        IMapper mapper)
    {
        Db = context;
        _dbSet = context.Set<T>();
        _mapper = mapper;
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
}