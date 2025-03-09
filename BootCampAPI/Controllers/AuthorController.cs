using BootCampAPI.Application.Commands.Authors.CreateAuthor;
using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("save")]
        public async Task<IActionResult> CreateAuthor(
            [FromQuery] int id,
            [FromQuery] string name,
            [FromQuery] int age,
            [FromQuery] string status)
        {
            var newAuthorCommand = new CreateAuthorCommand(id, name, age, status);

            var result = await _mediator.Send(newAuthorCommand);
            return Ok(result);
        }

    }
}
