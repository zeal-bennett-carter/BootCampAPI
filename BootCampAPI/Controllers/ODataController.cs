using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
using BootCampAPI.Application.Models.DTO;
using BootCampAPI.Application.Queries.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BootCampAPI.Controllers
{
    [Route("odata")]
    public class ODataController : Controller
    {
        private readonly IListAuthorsDataQuery _authorsQuery;
        private readonly IListBooksDataQuery _booksQuery;
        private readonly IListBookSeriesDataQuery _bookSeriesQuery;
        private readonly IMediator _mediator;

        public ODataController(IListAuthorsDataQuery authorsQuery, IListBooksDataQuery booksQuery, IListBookSeriesDataQuery bookSeriesQuery, IMediator mediator)
        {
            _authorsQuery = authorsQuery;
            _booksQuery = booksQuery;
            _bookSeriesQuery = bookSeriesQuery;
            _mediator = mediator;

        }

        [HttpGet("authors")]
        [EnableQuery]
        public IQueryable<ListAuthorsDataQueryResult> GetAuthors()
            => _authorsQuery.Execute();

        [HttpGet("books")]
        [EnableQuery]
        public IQueryable<ListBooksDataQueryResult> GetBooks()
            => _booksQuery.Execute();

        [HttpGet("bookSeries")]
        [EnableQuery]
        public IQueryable<ListBookSeriesDataQueryResult> GetBookSeries()
            => _bookSeriesQuery.Execute();


        [HttpGet("author/{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}
