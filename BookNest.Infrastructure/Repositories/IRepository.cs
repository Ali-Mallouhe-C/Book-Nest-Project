namespace BookNest.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>?> GetAsync(int pageNumber = 1, int pageSize = 10);

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity?> DeleteAsync(int id);

        Task<TEntity?> UpdateAsync(TEntity entity);

        Task<TEntity?> AddAsync(TEntity entity);
    }
}
