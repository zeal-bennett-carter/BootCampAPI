using BootCampAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Domain.Repositories
{
    internal interface IAuthorRepository
    {
        public Task<Author?> Get(int authorId);
        public Task Save(Author author);
    }
}
