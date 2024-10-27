using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        private readonly BookNestAppDbContext _context;
        private readonly UserRepository _repository;

        public EmployeeRepository(BookNestAppDbContext context, UserRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Employee?> Create(string userEmail, int branchId, decimal salary)
        {
            var user = await _repository.GetByEmail(userEmail);

            if (user is null)
                return null;

            user.RoleId = 2;

            var employee = new Employee
            {
                UserId = user.Id,
                BranchId = branchId,
                Salary = salary
            };


            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>?> GetAsync()
        {
            var employees = await _context.Employees.AsNoTracking().ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            return employee;
        }


    }

}
