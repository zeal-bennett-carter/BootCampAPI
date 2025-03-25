using BootCampAPI.Domain.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Data.Repositories
{
    public interface IAuthorRepository
    {
        public Task<Author?> Get(int authorId);
        public Task Save(Author author);
    }
}
