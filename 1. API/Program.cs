using _1._API.Mapper;
using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Clients;
using _3._Data.Context;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using _1._API.Middleware;
using _3._Data.Categories;
using _2._Domain.Categories;
using _3._Data.PostImages;
using _2._Domain.PostImages;
using _3._Data.Posts;
using _2._Domain.Posts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientData, ClientData>();
builder.Services.AddScoped<IClientDomain, ClientDomain>();

builder.Services.AddScoped<ICategoryData, CategoryData>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();

builder.Services.AddScoped<IPostImageData, PostImageData>();
builder.Services.AddScoped<IPostImageDomain, PostImageDomain>();

builder.Services.AddScoped<IPostData, PostData>();
builder.Services.AddScoped<IPostDomain, PostDomain>();

// Cadena de conexion
var ConnectionString = builder.Configuration.GetConnectionString("MinkaTradeBD");
builder.Services.AddDbContext<MinkaTradeBD>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(ConnectionString,
            ServerVersion.AutoDetect(ConnectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    }
);

// Automapper
builder.Services.AddAutoMapper(
    typeof(ModelToAPI),
    typeof(APIToModel)
);

var app = builder.Build();

// Validar que la base de datos no existe
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<MinkaTradeBD>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
