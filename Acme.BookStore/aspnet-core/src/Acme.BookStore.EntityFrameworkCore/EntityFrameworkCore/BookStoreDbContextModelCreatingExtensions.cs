using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BookStoreConsts.DbTablePrefix + "YourEntities", BookStoreConsts.DbSchema);

            //    //...
            //});

            builder.Entity<Book>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Book", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);

                b.HasData(new Book(Guid.NewGuid(), "1984", BookType.Dystopia, DateTime.Now, 19),
                    new Book(Guid.NewGuid(), "The Hitchhiker`s Guide to the Galaxy", BookType.ScienceFiction, DateTime.Now, 42),
                    new Book(Guid.NewGuid(), "Pet Sematary", BookType.Horror, DateTime.Now, 23));
            });
            //builder.Entity<Book>().HasData(new Book(Guid.NewGuid(), "1984", BookType.Dystopia, DateTime.Now, 19),
            //    new Book(Guid.NewGuid(), "The Hitchhiker`s Guide to the Galaxy", BookType.ScienceFiction, DateTime.Now, 42),
            //    new Book(Guid.NewGuid(), "Pet Sematary", BookType.Horror, DateTime.Now, 23));
        }
    }
}