namespace BooksStore.API.Contracts
{
    public record BooksRequest(
        Guid Id,
        string Title,
        string Description,
        decimal Price);
}