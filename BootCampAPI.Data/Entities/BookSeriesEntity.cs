using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Entities
{
    internal class BookSeriesEntity 
    {
        public int BookSeriesId { get; set; }
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
        public List<BookEntity> BooksInSeries { get; set; }
    }
}
