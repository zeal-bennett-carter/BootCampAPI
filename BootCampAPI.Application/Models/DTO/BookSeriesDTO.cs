using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Models.DTO
{
    public class BookSeriesDTO
    {
        public int BookSeriesId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<int> BooksInSeriesIDs { get; set; }
        public List<string> BooksInSeriesTitles { get; set; }
    }
}
