using Microsoft.EntityFrameworkCore;
using BootCampAPI.Data.Entities;

namespace BootCampAPI.Data
{
    public class BootCampDBContext: DbContext, IDatabase
    {
        public BootCampDBContext()
        {
        }

        public BootCampDBContext(DbContextOptions<BootCampDBContext> options)
            : base(options)
        {
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<BookSeriesEntity> BookSeries { get; set; }


        public void Migrate()
            => base.Database.Migrate();
    }
}
