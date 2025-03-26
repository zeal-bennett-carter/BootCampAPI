using BootCampAPI.Application.Commands.Books.CreateBook;
using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Application.Models.DTO;
using BootCampAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Books.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDTO>
    {

        private readonly IBookRepository _BookRepository;

        public CreateBookCommandHandler(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        public async Task<BookDTO> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {

            var book = Book.Create(command.BookId, command.Title, command.AuthorName, command.Genre, command.Description, command.PageCount, command.PagesRead, command.Publisher);

            await _BookRepository.Save(book);

            return new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.AuthorName,
                Genre = book.Genre,
                Description = book.Description,
                PageCount = book.PageCount,
                PagesRead = book.PagesRead,
                Publisher = book.Publisher
            };
        }
    }
}
