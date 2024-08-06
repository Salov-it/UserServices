using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MSSQL.Application.Context;
using MSSQL.Application.DependencyInjection;
using UserService.Application.Dependencyinjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMSSQLApplication(builder.Configuration);

builder.Services.AddUserServiceApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Создаем базу данных и применяем миграции при запуске приложения
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    dbContext.Database.Migrate();
}

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
