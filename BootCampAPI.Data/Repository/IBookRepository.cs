using BootCampAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Repository
{
    public interface IBookRepository
    {
        public Task<Book?> Get(int bookId);
        public Task Save(Book book);
    }
}
