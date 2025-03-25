using BootCampAPI.Domain.Models;
using BootCampAPI.Domain.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Queries.ListBookSeries
{
    public class ListBookSeriesDataQueryResult
    {
        public int BookSeriesId { get; set; }
        public Author Author { get; set; }
        public List<Book> BooksInSeries { get; set; }
    }
}
