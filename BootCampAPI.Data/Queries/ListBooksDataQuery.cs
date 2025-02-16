using BootCampAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BootCampAPI.Application.Data.Queries.ListBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Queries
{
    internal class ListBooksDataQuery(BootCampDBContext db) : IListBooksDataQuery
    {
        public IQueryable<ListBooksDataQueryResult> Execute()
            => db.Set<BookEntity>().AsNoTracking().Select(a => new ListBooksDataQueryResult
            {
                BookId = a.BookId,
                Title = a.Title,
                AuthorName = a.Author.Name,
                Genre = a.Genre,
                Description = a.Description,
                PageCount = a.PageCount,
                PagesRead = a.PagesRead,
                Publisher = a.Publisher
            });
    }
}

