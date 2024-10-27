using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;

namespace BookNest.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(BookNestAppDbContext context) : base(context)
        {
        }
    }

}
