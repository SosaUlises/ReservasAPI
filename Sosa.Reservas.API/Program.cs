using Sosa.Reservas.API;
using Sosa.Reservas.Application;
using Sosa.Reservas.Common;
using Sosa.Reservas.External;
using Sosa.Reservas.Persistence;
using Sosa.Reservas.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Configuración de los servicios del contenedor
builder.Services.AddControllers();
builder.Services.AddOpenApi();


// Inyección de dependencias
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);


// Configuración de la autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await IdentityDataSeeder.SeedRolesAsync(app);

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();