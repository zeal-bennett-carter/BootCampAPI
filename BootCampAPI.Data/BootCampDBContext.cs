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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=books.db"); // Set your database provider
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity
                    .ToTable("Book")
                    .HasKey(e => e.BookId);

                entity
                    .Property(i => i.Title)
                    .HasMaxLength(200)
                    .IsRequired();

                entity
                    .Property(i => i.AuthorName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity
                    .Property(i => i.Genre)
                    .HasMaxLength(50)
                    .IsRequired();

                entity
                    .Property(i => i.Description)
                    .HasMaxLength(500)
                    .IsRequired();

                entity
                    .Property(i => i.PageCount)
                    .IsRequired();

                entity
                    .Property(i => i.PagesRead)
                    .IsRequired();
            });

            modelBuilder.Entity<BookEntity>()
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorID);

            modelBuilder.Entity<BookEntity>()
                .HasOne(e => e.BookSeries)
                .WithMany()
                .HasForeignKey(e => e.BookSeriesID);

            modelBuilder.Entity<BookSeriesEntity>()
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId);
        }
    }

}
