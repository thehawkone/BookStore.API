namespace BooksStore.Core.Models
{
    public class Book
    {
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        
        public Guid Id { get; }
        
        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;
        
        public decimal Price { get; }
    }
}