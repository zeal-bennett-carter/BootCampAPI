using BootCampAPI.Application.Data.Queries.ListAuthors;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BootCampAPI.Configuration
{
    public static class ODataConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            EntitySetConfiguration<ListAuthorsDataQueryResult> formDetailSet = builder.EntitySet<ListAuthorsDataQueryResult>("forms");
            formDetailSet.EntityType.HasKey(r => r.AuthorId);

            return builder.GetEdmModel();
        }
    }
}
