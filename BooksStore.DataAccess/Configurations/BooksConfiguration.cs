using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BooksStore.Core.Models;
using BooksStore.DataAccess.Entites;

namespace BooksStore.DataAccess.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Books.MaxTitleLength)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();
        }
    }
}