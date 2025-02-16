using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
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

        public ODataController(IListAuthorsDataQuery authorsQuery, IListBooksDataQuery booksQuery, IListBookSeriesDataQuery bookSeriesQuery)
        {
            _authorsQuery = authorsQuery;
            _booksQuery = booksQuery;
            _bookSeriesQuery = bookSeriesQuery;

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
    }
}
