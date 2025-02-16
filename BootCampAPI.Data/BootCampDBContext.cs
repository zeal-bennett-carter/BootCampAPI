using Microsoft.EntityFrameworkCore;
using BootCampAPI.Data.Entities;

namespace BootCampAPI.Data
{
    internal class BootCampDBContext: DbContext, IDatabase // make this internal, if we dont make it internal it makes it easy to access in different layers
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
        // you code your entities and the migrations will create a database schema using the a command from microsoft

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=books.db"); // Set your database provider
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>(entity =>
            {
                entity.ToTable("Author").HasKey(e => e.AuthorId);
                entity.Property(i => i.Name).HasMaxLength(200).IsRequired();
                entity.Property(i => i.Age).IsRequired();
                entity.Property(i => i.Status).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.ToTable("Book").HasKey(e => e.BookId);
                entity.Property(i => i.AuthorID).IsRequired();
                entity.Property(i => i.BookSeriesID).IsRequired(false);
                entity.Property(i => i.Title).HasMaxLength(200).IsRequired();
                entity.Property(i => i.AuthorName).HasMaxLength(100).IsRequired();
                entity.Property(i => i.Genre).HasMaxLength(50).IsRequired();
                entity.Property(i => i.Description).HasMaxLength(500).IsRequired();
                entity.Property(i => i.PageCount).IsRequired();
                entity.Property(i => i.PagesRead).IsRequired();

                entity.HasOne(e => e.Author)
                      .WithMany()
                      .HasForeignKey(e => e.AuthorID);

                entity.HasOne(e => e.BookSeries)
                      .WithMany(bs => bs.BooksInSeries)
                      .HasForeignKey(e => e.BookSeriesID);
            });

            modelBuilder.Entity<BookSeriesEntity>(entity =>
            {
                entity.ToTable("BookSeries").HasKey(e => e.BookSeriesId);
                entity.Property(i => i.AuthorId).IsRequired();

                entity.HasOne(e => e.Author)
                      .WithMany()
                      .HasForeignKey(e => e.AuthorId);

                entity.HasMany(bs => bs.BooksInSeries)
                      .WithOne(b => b.BookSeries)
                      .HasForeignKey(b => b.BookSeriesID);
            });
        }
    }

}
