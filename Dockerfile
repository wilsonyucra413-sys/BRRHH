# Usa la imagen completa del SDK de .NET para compilar la aplicación.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copia solo el archivo .csproj para aprovechar la caché de Docker al restaurar paquetes.
# Se asume que RRHH.csproj está en la raíz del contexto de compilación.
COPY ["RRHH.csproj", "./"]
RUN dotnet restore "./RRHH.csproj"
# Copia el resto del código fuente.
COPY . .
# Compila la aplicación.
RUN dotnet build "RRHH.csproj" -c $BUILD_CONFIGURATION -o /app/build
# La etapa de publicación toma el resultado de la compilación y lo prepara para producción.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RRHH.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
# La etapa final usa la imagen ligera de ASP.NET Core para ejecutar la aplicación.
# Esto crea una imagen final más pequeña y segura.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
# Copia solo los archivos publicados de la etapa 'publish'.
COPY --from=publish /app/publish ./
# Expone el puerto que la aplicación escuchará dentro del contenedor.
EXPOSE 8080
# Define el comando para iniciar la aplicación cuando se ejecute el contenedor.
ENTRYPOINT ["dotnet", "RRHH.dll"]