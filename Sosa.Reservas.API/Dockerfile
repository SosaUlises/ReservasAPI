# 1. Imagen base para compilar (SDK de .NET 8)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo de solución (si existe) para mantener contexto
COPY *.sln ./

# Copiar los archivos de proyecto (.csproj) de TODAS las capas
# Es vital mantener la estructura de carpetas exacta
COPY Sosa.Reservas.API/Sosa.Reservas.API.csproj Sosa.Reservas.API/
COPY Sosa.Reservas.Application/Sosa.Reservas.Application.csproj Sosa.Reservas.Application/
COPY Sosa.Reservas.Domain/Sosa.Reservas.Domain.csproj Sosa.Reservas.Domain/
COPY Sosa.Reservas.Common/Sosa.Reservas.Common.csproj Sosa.Reservas.Common/
COPY Sosa.Reservas.External/Sosa.Reservas.External.csproj Sosa.Reservas.External/
COPY Sosa.Reservas.Persistence/Sosa.Reservas.Persistence.csproj Sosa.Reservas.Persistence/

# Restaurar dependencias (esto usa la caché de Docker para ser más rápido en el futuro)
RUN dotnet restore

# Copiar el resto del código fuente
COPY . .

# Compilar y publicar la API
WORKDIR "/src/Sosa.Reservas.API"
RUN dotnet publish -c Release -o /app/publish

# 2. Imagen final para ejecución (Runtime optimizado)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar los binarios compilados desde la etapa anterior
COPY --from=build /app/publish .

# Configuración de puerto para Render / Koyeb (Puerto 8080)
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# Punto de entrada: Ejecutar la API
ENTRYPOINT ["dotnet", "Sosa.Reservas.API.dll"]