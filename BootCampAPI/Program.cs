using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Application.Extensions;
using BootCampAPI.Configuration;
using BootCampAPI.Data.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
   .AddApplicationServices()
   .AddDataServices()
   .AddControllers()

    .AddOData(opt =>
        {
            opt
                .AddRouteComponents("odata", ODataConfiguration.GetEdmModel())
                .EnableQueryFeatures(100);
            opt.TimeZone = TimeZoneInfo.Utc;
        })
    .AddODataNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
