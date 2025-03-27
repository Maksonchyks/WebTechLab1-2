using Lab1_2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Налаштування підключення до бази даних
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        "Host=dpg-cvimu3t6ubrc7389ivq0-a.frankfurt-postgres.render.com;Database=makson;Username=makson;Password=lV1Yj7LjA445D0jgXX5jig7EbqPQh86G;Trust Server Certificate=true"
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
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();