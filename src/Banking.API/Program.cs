using Banking.Application.DependencyInjection;
using Banking.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// 2. Добавляем поддержку контроллеров
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();


// OpenAPI/Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Если хочешь классический интерфейс Swagger, можно добавить app.UseSwaggerUI()
}

app.UseHttpsRedirection();

// 3. Сопоставляем контроллеры
app.MapControllers();

app.Run();