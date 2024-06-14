using BooksStore.Core.Models;

namespace BooksStore.Core.Abstractions
{
    public interface IBooksRepository
    {
        Task<List<Books>> Get();
        Task<Guid> Create(Books books);
        Task<Guid> Update(Guid id, string title, string description, decimal price);
        Task<Guid> Delete(Guid id);
    }
}