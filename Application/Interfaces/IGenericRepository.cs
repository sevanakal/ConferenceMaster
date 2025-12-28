
namespace ConfereneceMaster.Application.Interfaces
{
    public  interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
