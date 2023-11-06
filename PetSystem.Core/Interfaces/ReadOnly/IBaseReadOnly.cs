namespace PetSystem.Core.Interfaces.ReadOnly;

public interface IBaseReadOnly<T> where T : class
{
    Task<T> GetById(Guid id);
}