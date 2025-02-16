using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Queries.ListBookSeries
{
    public interface IListBookSeriesDataQuery
    {
        IQueryable<ListBookSeriesDataQueryResult> Execute();
    }
}

