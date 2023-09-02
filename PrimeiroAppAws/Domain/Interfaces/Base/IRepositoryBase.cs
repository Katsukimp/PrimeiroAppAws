namespace PrimeiroAppAws.Domain.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
