using BooksStore.Core.Models;

namespace BooksStore.Core.Abstractions
{
    public interface IBooksService
    {
        Task<List<Books>> GetAllBooks();
        Task<Guid> CreateBook(Books books);
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
        Task<Guid> DeleteBook(Guid id);
    }
}