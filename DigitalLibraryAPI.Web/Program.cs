using DigitalLibraryAPI.DataAccess;
using DigitalLibraryAPI.Repositories;
using DigitalLibraryAPI.Repositories.Contracts;
using DigitalLibraryAPI.Repositories.Contracts.Mappers;
using DigitalLibraryAPI.Repositories.Mappers;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlDataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySQLBooksConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IBookMapper, BookMapper>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

// don't want to show swagger on prod? uncomment if statement
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

app.Run();
