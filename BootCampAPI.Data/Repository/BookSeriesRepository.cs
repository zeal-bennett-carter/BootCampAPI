using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Data.Entities;
using BootCampAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Repository
{
    internal class BookSeriesRepository : IBookSeriesRepository
    {
        private readonly BootCampDBContext db;
        private readonly IAuthorRepository authorRepository;
        private readonly IBookRepository bookRepository;

        public BookSeriesRepository(BootCampDBContext db, IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            this.db = db;
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
        }

        public async Task<BookSeries?> Get(int bookSeriesId)
        {
            var entity = db.Set<BookSeriesEntity>()
                .Include(e => e.BooksInSeries)
                .Include(e => e.Author)
                .FirstOrDefault(e => e.BookSeriesId == bookSeriesId);

            if (entity == null)
            {
                return null;
            }

            var author = await authorRepository.Get(entity.AuthorId);
            var books = new List<Book>();

            foreach (var bookEntity in entity.BooksInSeries)
            {
                var book = await bookRepository.Get(bookEntity.BookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }

            return await Task.FromResult(new BookSeries(
                entity.BookSeriesId,
                author,
                books
            ));
        }

        public async Task Save(BookSeries bookSeries)
        {
            var bookSeriesEntity = db.Set<BookSeriesEntity>()
                .FirstOrDefault(e => e.BookSeriesId == bookSeries.BookSeriesId);

            if (bookSeriesEntity == null)
            {
                bookSeriesEntity = new BookSeriesEntity
                {
                    BookSeriesId = bookSeries.BookSeriesId,
                    AuthorId = bookSeries.Author.AuthorId,
                };

                var AuthorEntity = db.Set<AuthorEntity>()
                .FirstOrDefault(e => e.AuthorId == bookSeries.Author.AuthorId);

                var bookEntities = new List<BookEntity>();

                foreach (var bookEntity in bookSeriesEntity.BooksInSeries)
                {
                    var book = await bookRepository.Get(bookEntity.BookId);
                    if (book != null)
                    {
                        bookEntities.Add(new BookEntity
                        {
                            BookId = book.BookId,
                            Title = book.Title,
                            AuthorName = book.AuthorName,
                            Genre = book.Genre,
                            Description = book.Description,
                            PageCount = book.PageCount,
                            PagesRead = book.PagesRead,
                            Publisher = book.Publisher
                        });
                    }
                }

                bookSeriesEntity.Author = AuthorEntity;
                bookSeriesEntity.BooksInSeries = bookEntities;

                db.Add(bookSeriesEntity);
            }

            await db.SaveChangesAsync();
        }
    }
}