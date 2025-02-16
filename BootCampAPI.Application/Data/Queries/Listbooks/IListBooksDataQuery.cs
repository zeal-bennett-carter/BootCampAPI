using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Queries.ListBooks
{
    public interface IListBooksDataQuery
    {
        IQueryable<ListBooksDataQueryResult> Execute();
    }
}

