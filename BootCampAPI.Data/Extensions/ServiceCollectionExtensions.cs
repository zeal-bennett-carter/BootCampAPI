using BootCampAPI.Application.Data;
using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Data.Queries.ListBooks;
using BootCampAPI.Application.Data.Queries.ListBookSeries;
using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Data.Queries;
using BootCampAPI.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IDatabase, BootCampDBContext>()
            .AddScoped<IDatastore, BootCampDBContext>()

            .AddScoped<IListAuthorsDataQuery, ListAuthorsDataQuery>()
            .AddScoped<IListBooksDataQuery, ListBooksDataQuery>()
            .AddScoped<IListBookSeriesDataQuery, ListBookSeriesDataQuery>()

            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBookSeriesRepository, BookSeriesRepository>()


            .AddDbContext<BootCampDBContext>(options =>
            {
                options.UseSqlite("Data Source=C:\\Users\\benne\\source\\repos\\BootCampAPI\\BootCampAPI.Data\\books.db");
            });

    }
}
