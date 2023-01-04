#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
COPY ./PlantHere.Application/PlantHere.Application.csproj ./PlantHere.Application/
COPY ./PlantHere.Domain/PlantHere.Domain.csproj ./PlantHere.Domain/
COPY ./PlantHere/PlantHere.WebAPI.csproj ./PlantHere/
COPY ./PlantHere.Infrastructure/PlantHere.Infrastructure.csproj ./PlantHere.Infrastructure/
COPY ./PlantHere.Persistence/PlantHere.Persistence.csproj ./PlantHere.Persistence/

# .NET Core Restore
RUN dotnet restore ./PlantHere/PlantHere.WebAPI.csproj

# Copy All Files
COPY . ./

# .NET Core Build and Publish
RUN dotnet publish ./PlantHere/PlantHere.WebAPI.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://*:4500
ENTRYPOINT ["dotnet", "PlantHere.WebAPI.dll"]