using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Models.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public int AuthorID { get; set; }
        public int? BookSeriesID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public int PagesRead { get; set; }
        public string Publisher { get; set; }
        public string BookSeriesName { get; set; }
    }
}
