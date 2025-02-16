using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Queries.ListAuthors
{
    public interface IListAuthorsDataQuery
    {
        IQueryable<ListAuthorsDataQueryResult> Execute();
    }
}
