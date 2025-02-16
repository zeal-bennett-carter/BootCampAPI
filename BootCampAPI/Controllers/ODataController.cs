using BootCampAPI.Application.Data.Queries.ListAuthors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BootCampAPI.Controllers
{
    [Route("odata")]
    public class ODataController(IListAuthorsDataQuery query) : Controller
    {
        [HttpGet("characters")]
        [EnableQuery]
        public IQueryable<ListAuthorsDataQueryResult> GetAuthors()
            => query.Execute();
    }
}
