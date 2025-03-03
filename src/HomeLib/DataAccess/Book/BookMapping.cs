using HomeLib.DataAccess.Book.Commands;
using HomeLib.DataAccess.Book.Queries;
using Riok.Mapperly.Abstractions;

namespace HomeLib.DataAccess.Book;

[Mapper]
public static partial class BookMapping
{
    // Commands
    public static partial BookEntity MapToBookEntity(this AddBookCommand book);

    public static partial BookEntity MapToBookEntity(this UpdateBookCommand book);

    // Queries
    public static partial BookDetails MapToBookDetails(this BookEntity book);

    public static partial BookCollectionItem MapToBookCollectionItem(this BookEntity book);
}
