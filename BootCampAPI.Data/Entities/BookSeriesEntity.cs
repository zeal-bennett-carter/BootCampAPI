using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Entities
{
    public class BookSeriesEntity
    {
        public int BookSeriesId { get; set; }
        public AuthorEntity Author { get; set; }
        private List<BookEntity> BooksInSeries { get; set; }
    }
}
