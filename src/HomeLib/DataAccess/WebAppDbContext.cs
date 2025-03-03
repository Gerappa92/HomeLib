using HomeLib.DataAccess.Book;
using Microsoft.EntityFrameworkCore;

namespace HomeLib.DataAccess;

public class WebAppDbContext : DbContext
{
    public WebAppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<BookEntity> Books { get; set; }
}
