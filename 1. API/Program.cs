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
using _3._Data.Reviews;
using _2._Domain.Reviews;
using _3._Data.Chats;
using _2._Domain.Chats;
using _3._Data.Messages;
using _2._Domain.Messages;
using _3._Data.Premiuns;
using _2._Domain.Premiuns;
using _3._Data.Suscriptions;
using _2._Domain.Suscriptions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using _3._Data.Users;
using _2._Domain.Users;
using _2._Domain.Token;
using _1._API.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MinkaTrade API",
        Description = "API to Manage MinkaTrade Marketplace Data",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Agustin Aguilar Lindo",
            Url = new Uri("https://www.linkedin.com/in/agustin-aguilar-lindo-80a9872b8/")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IClientData, ClientData>();
builder.Services.AddScoped<IClientDomain, ClientDomain>();

builder.Services.AddScoped<ICategoryData, CategoryData>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();

builder.Services.AddScoped<IPostImageData, PostImageData>();
builder.Services.AddScoped<IPostImageDomain, PostImageDomain>();

builder.Services.AddScoped<IPostData, PostData>();
builder.Services.AddScoped<IPostDomain, PostDomain>();

builder.Services.AddScoped<IReviewData, ReviewData>();
builder.Services.AddScoped<IReviewDomain, ReviewDomain>();

builder.Services.AddScoped<IChatData, ChatData>();
builder.Services.AddScoped<IChatDomain, ChatDomain>();

builder.Services.AddScoped<IMessageData, MessageData>();
builder.Services.AddScoped<IMessageDomain, MessageDomain>();

builder.Services.AddScoped<IPremiunData, PremiunData>();
builder.Services.AddScoped<IPremiunDomain, PremiunDomain>();

builder.Services.AddScoped<ISuscriptionData, SuscriptionData>();
builder.Services.AddScoped<ISuscriptionDomain, SuscriptionDomain>();

builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<ITokenService, TokenService>();

//jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

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

//CORS
app.UseCors(MyAllowSpecificOrigins);

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

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
