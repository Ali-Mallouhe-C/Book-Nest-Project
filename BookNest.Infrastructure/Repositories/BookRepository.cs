using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using BookNest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class BookRepository : GenericRepository<Book>
{
    private readonly BookNestAppDbContext _context;

    public BookRepository(BookNestAppDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<Book>?> GetByAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author name cannot be null or empty.");

        var response = await _context.Books
                            .AsNoTracking()
                            .Where(b => b.Author.Name == author)
                            .ToListAsync();
        return response;
    }

    public async Task<List<Book>?> GetByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Author name cannot be null or empty.");

        var response = await _context.Books
                            .AsNoTracking()
                            .Where(b => b.Category.Name == category)
                            .ToListAsync();
        return response;
    }

    public override async Task<Book?> GetByIdAsync(int id)
    {
        var response = await _context.Books
                                .AsNoTracking()
                                .Where(b => b.Id == id)
                                .Include(b => b.Author)
                                .Include(b => b.Category)
                                .Include(b => b.Ratings)
                                .FirstOrDefaultAsync();
        return response;
    }
}