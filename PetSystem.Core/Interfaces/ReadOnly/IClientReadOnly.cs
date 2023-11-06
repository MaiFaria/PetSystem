using PetSystem.Core.Entities.Models;

namespace PetSystem.Core.Interfaces.ReadOnly;

public interface IClientReadOnly : IBaseReadOnly<Client>
{
    Task<Client> GetByIdClient(Guid id);
}
