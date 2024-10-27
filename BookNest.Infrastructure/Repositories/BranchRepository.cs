using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;

namespace BookNest.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch>
    {
        public BranchRepository(BookNestAppDbContext context) : base(context)
        {
        }
    }

}
