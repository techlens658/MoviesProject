// Program.cs file is the entry point of the application
//The args is arguments provided by the runtime environment when the application is launched
using MoviesProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AddController 
// Attribute Routing is used 
builder.Services.AddControllers();

// For using appSettings.development.json file using IOptions
builder.Services.AddOptions();
builder.Services.Configure<MySettings>(
    builder.Configuration.GetSection("MySettings"));
builder.Services.Configure<AnotherSettings>(
    builder.Configuration.GetSection("AnotherSettings"));

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
