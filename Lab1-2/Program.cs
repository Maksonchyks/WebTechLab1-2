using Lab1_2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Налаштування підключення до бази даних
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        "server=localhost;database=Makson;user=root;password=1234",
        new MySqlServerVersion(new Version(8, 0, 41))
    )
);

// Додавання служб
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Makson API",
        Version = "v1"
    });
});

var app = builder.Build();

// Налаштування Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();