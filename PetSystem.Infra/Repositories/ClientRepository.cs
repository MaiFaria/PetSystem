using PetSystem.Core.Entities.Models;
using PetSystem.Core.Interfaces.ReadOnly;
using PetSystem.Infra.Data;

namespace PetSystem.Infra.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(PersistContext context)
        : base(context)
    { }
}