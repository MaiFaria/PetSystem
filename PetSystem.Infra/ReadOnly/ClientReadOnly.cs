using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetSystem.Core.Entities.Models;
using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Infra.Data;

namespace PetSystem.Infra.ReadOnly;

public class ClientReadOnly : BaseReadOnly<Client>, IClientReadOnly
{
    public ClientReadOnly(PersistContext context,
                          IMapper mapper) : base(context, mapper)
    {}

    public async Task<Client> GetByIdClient(Guid id)
    {
        return await _dbSet.Where(c => c.Id.Equals(id))
                           .AsNoTracking()
                           .FirstOrDefaultAsync();
    }
}