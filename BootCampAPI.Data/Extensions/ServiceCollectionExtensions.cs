using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            .AddScoped<IListAuthorsDataQuery, ListAuthorsDataQuery>()
            .AddDbContext<BootCampDBContext>(options =>
            {
                options.UseSqlite("Data Source=app.db");
            });
    }
}
