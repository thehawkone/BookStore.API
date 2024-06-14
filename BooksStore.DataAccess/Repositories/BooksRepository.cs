using BooksStore.Core.Abstractions;
using BooksStore.Core.Models;
using BooksStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksStoreDbContext _context;

        public BooksRepository(BooksStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Books>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities.Select(b => Books
                .Create(b.Id, b.Title, b.Description, b.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Books books)
        {
            var bookEntity = new BookEntity
            {
                Id = books.Id,
                Title = books.Title,
                Description = books.Description,
                Price = books.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return books.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}