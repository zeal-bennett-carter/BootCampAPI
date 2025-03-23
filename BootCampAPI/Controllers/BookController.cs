using BootCampAPI.Application.Commands.Authors.CreateAuthor;
using BootCampAPI.Application.Commands.Books.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("save")]
        public async Task<IActionResult> CreateBook(
            [FromQuery] int bookId,
            [FromQuery] string title,
            [FromQuery] int authorId,
            [FromQuery] string authorName,
            [FromQuery] string genre,
            [FromQuery] string description,
            [FromQuery] int pageCount,
            [FromQuery] int pagesRead,
            [FromQuery] string publisher)
        {
            var newBookCommand = new CreateBookCommand(bookId, title, authorId, authorName, genre, description, pageCount, pagesRead, publisher);

            var result = await _mediator.Send(newBookCommand);
            return Ok(result);
        }
    }
}
