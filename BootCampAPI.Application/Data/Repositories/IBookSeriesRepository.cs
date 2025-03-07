using BootCampAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Repositories
{
    public interface IBookSeriesRepository
    {
        public Task<BookSeries?> Get(int bookSeriesId);
        public Task Save(BookSeries bookSeries);
    }
}
