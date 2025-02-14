using HomeLib.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeLib.DataAcces;

public class WebAppDbContext : DbContext
{
    public WebAppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<BookEntity> Books { get; set; }
}
