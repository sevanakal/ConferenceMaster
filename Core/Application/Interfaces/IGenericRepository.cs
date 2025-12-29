
namespace ConfereneceMaster.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity); // İsmi Update olarak kalsın, Task dönmesine gerek yok
    }
}
