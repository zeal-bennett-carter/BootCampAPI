using BootCampAPI.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Books.CreateBook
{
    public record CreateBookCommand(
        int BookId,
        string Title,
        string AuthorName,
        string Genre,
        string Description,
        int PageCount,
        int PagesRead,
        string Publisher
        ) : CommandBase<BookDTO>
    {
    }
}
