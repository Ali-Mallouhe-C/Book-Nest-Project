using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BookNestAppDbContext _context;

        public GenericRepository(BookNestAppDbContext context)
        {
            _context = context;
        }

        //return list of entities with size (pageSize) 
        public async Task<List<TEntity>?> GetAsync(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _context.Set<TEntity>()
                                        .AsNoTracking()
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return response;
        }


        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var response = await _context.FindAsync<TEntity>(id) as TEntity;

            return response;
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);

            if (entity == null)
                return entity;

            _context.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                return null;
            var response = _context
                                .Update<TEntity>(entity)
                                .Entity;

            await _context.SaveChangesAsync();
            return response;
        }

        public virtual async Task<TEntity?> AddAsync(TEntity entity)
        {
            if (entity == null)
                return entity;

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
