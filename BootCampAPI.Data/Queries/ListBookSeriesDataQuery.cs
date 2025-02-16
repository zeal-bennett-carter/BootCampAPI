using BootCampAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampAPI.Data.Repository;

namespace BootCampAPI.Data.Queries
{
    internal class ListBookSeriesDataQuery : IListBookSeriesDataQuery
    {
        private readonly BootCampDBContext db;
        private readonly AuthorRepository authorRepository;
        private readonly BookRepository bookRepository;

        public ListBookSeriesDataQuery(BootCampDBContext db, AuthorRepository authorRepository, BookRepository bookRepository)
        {
            this.db = db;
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
        }

        public IQueryable<ListBookSeriesDataQueryResult> Execute()
        {
            var bookSeriesEntities = db.Set<BookSeriesEntity>().AsNoTracking().ToList();

            var results = new List<ListBookSeriesDataQueryResult>();

            foreach (var entity in bookSeriesEntities)
            {
                var author = authorRepository.Get(entity.AuthorId).Result;
                var books = entity.BooksInSeries.Select(bookEntity => bookRepository.Get(bookEntity.BookId).Result).Where(book => book != null).ToList();

                results.Add(new ListBookSeriesDataQueryResult
                {
                    BookSeriesId = entity.BookSeriesId,
                    Author = author,
                    BooksInSeries = books
                });
            }

            return results.AsQueryable();
        }
    }
}

