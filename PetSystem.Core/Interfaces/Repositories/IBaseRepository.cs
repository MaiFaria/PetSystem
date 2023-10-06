namespace PetSystem.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteList(ICollection<T> entity);
}