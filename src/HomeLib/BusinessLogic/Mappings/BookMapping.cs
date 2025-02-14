using HomeLib.BusinessLogic.Commands.Books;
using HomeLib.BusinessLogic.Queries.Books;
using HomeLib.DataAcces.Entities;
using Riok.Mapperly.Abstractions;

namespace HomeLib.BusinessLogic.Mappings;

[Mapper]
public static partial class BookMapping
{
    public static partial BookEntity MapToBookEntity(this AddBookCommand book);

    public static partial BookEntity MapToBookEntity(this UpdateBookCommand book);

    public static partial BookDetails MapToBookDetails(this BookEntity book);

    public static partial BookCollectionItem MapToBookCollectionItem(this BookEntity book);
}
