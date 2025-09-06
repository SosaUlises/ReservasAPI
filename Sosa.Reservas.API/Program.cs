using Microsoft.EntityFrameworkCore;
using Sosa.Reservas.Application.Interfaces;
using Sosa.Reservas.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();



// Conexion Db
builder.Services.AddDbContext<DataBaseService>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionStrings")));

// Inyecciones de dependencia servicios
builder.Services.AddScoped<IDataBaseService, DataBaseService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
