
// Program.cs file is the entry point of the application
//The args is arguments provided by the runtime environment when the application is launched
using Microsoft.EntityFrameworkCore;
using MoviesProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddController 
// Attribute Routing is used
builder.Services.AddControllers();

//adding db context service
builder.Services.AddDbContext<MovieContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));

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
