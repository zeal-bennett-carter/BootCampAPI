using BootCampAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BootCampAPI.Application.Data.Queries.ListAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Queries
{
    internal class ListAuthorsDataQuery(BootCampDBContext db) : IListAuthorsDataQuery
    {
        public IQueryable<ListAuthorsDataQueryResult> Execute()
            => db.Set<AuthorEntity>().AsNoTracking().Select( a=> new ListAuthorsDataQueryResult
            {
                AuthorId = a.AuthorId,
                Name = a.Name,
                Age = a.Age,
                Status = a.Status
            });
    }
}
