using BootCampAPI.Data.Entities;
using BootCampAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Repository
{
    internal class BookRepository(BootCampDBContext db) : IAuthorRepository
    {
        public async Task<Book?> Get(int bookId)
        {
            var entity = db.Set<BookEntity>()
                .FirstOrDefault(e => e.BookId == bookId);

            if (entity == null)
            {
                return null;
            }

            return await Task.FromResult(new Book(
                entity.BookId,
                entity.Title,
                entity.AuthorName,
                entity.Genre,
                entity.Description,
                entity.PageCount,   
                entity.PagesRead,
                entity.Publisher
                ));
        }

        public async Task Save(Book book)
        {
            var entity = db.Set<BookEntity>()
                .FirstOrDefault(e => e.BookId == book.BookId);

            if (entity == null)
            {
                entity = new BookEntity
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    AuthorName = book.AuthorName,
                    Genre = book.Genre,
                    Description = book.Description,
                    PageCount = book.PageCount,
                    PagesRead = book.PagesRead,
                    Publisher = book.Publisher
                };
                db.Add(entity);
            }

            await db.SaveChangesAsync();
        }
    }
}
