using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BootCampAPI.Controllers
{
    [Route("odata")]
    public class ODataController : Controller
    {
        private readonly IListAuthorsDataQuery _authorsQuery;
        private readonly IListBooksDataQuery _booksQuery;

        public ODataController(IListAuthorsDataQuery authorsQuery, IListBooksDataQuery booksQuery)
        {
            _authorsQuery = authorsQuery;
            _booksQuery = booksQuery;
        }

        [HttpGet("authors")]
        [EnableQuery]
        public IQueryable<ListAuthorsDataQueryResult> GetAuthors()
            => _authorsQuery.Execute();

        [HttpGet("books")]
        [EnableQuery]
        public IQueryable<ListBooksDataQueryResult> GetBooks()
            => _booksQuery.Execute();
    }
}
