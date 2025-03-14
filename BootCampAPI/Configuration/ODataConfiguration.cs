﻿using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BootCampAPI.Configuration
{
    public static class ODataConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            // Configure ListAuthorsDataQueryResult entity set
            EntitySetConfiguration<ListAuthorsDataQueryResult> authorsSet = builder.EntitySet<ListAuthorsDataQueryResult>("authors");
            authorsSet.EntityType.HasKey(r => r.AuthorId);

            // Configure ListBooksDataQueryResult entity set
            EntitySetConfiguration<ListBooksDataQueryResult> booksSet = builder.EntitySet<ListBooksDataQueryResult>("books");
            booksSet.EntityType.HasKey(r => r.BookId);

            // Configure ListBookSeriesDataQueryResult entity set
            EntitySetConfiguration<ListBookSeriesDataQueryResult> bookSeriesSet = builder.EntitySet<ListBookSeriesDataQueryResult>("bookSeries");
            bookSeriesSet.EntityType.HasKey(r => r.BookSeriesId);

            return builder.GetEdmModel();
        }
    }
}
