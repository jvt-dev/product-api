namespace ProdutoApi.Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T?> GetEntityById(long id);
        Task<List<T>> GetAll();
    }
}
