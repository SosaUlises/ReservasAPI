using Sosa.Reservas.API;
using Sosa.Reservas.Application;
using Sosa.Reservas.Application.DataBase.Cliente.Commands.CreateCliente;
using Sosa.Reservas.Application.DataBase.Usuario.Queries.GetAllUsuarios;
using Sosa.Reservas.Common;
using Sosa.Reservas.External;
using Sosa.Reservas.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Inyeccion de dependencias
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapPost("/testService", async (ICreateClienteCommand service) =>
{
    var model = new CreateClienteModel
    {
        FullName = "",
        DNI = "123345"
    };
    return await service.Execute(model);
});

app.Run();
