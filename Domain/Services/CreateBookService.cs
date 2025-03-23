using BootCampAPI.Application.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Services
{
    internal class CreateBookService
    {
        private readonly IAuthorRepository _authorRepository;
        public CreateBookService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<bool> ValidateAuthor(int authorId)
        {
            var author = await _authorRepository.Get(authorId);
            if (author == null)
            {
                return false;
            }
            return true;
        }
    }
}
