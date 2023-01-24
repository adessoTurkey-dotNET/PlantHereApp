#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects

COPY ./PlantHere.Test/*.csproj ./PlantHere.Test/
COPY ./PlantHere.Application/*.csproj ./PlantHere.Application/
COPY ./PlantHere.Domain/*.csproj ./PlantHere.Domain/
COPY ./PlantHere/*.csproj ./PlantHere/
COPY ./PlantHere.Infrastructure/*.csproj ./PlantHere.Infrastructure/
COPY ./PlantHere.Persistence/*.csproj ./PlantHere.Persistence/
COPY *.sln .

# .NET Core Restore
RUN dotnet restore

# Copy All Files
COPY . .

# .NET Core Test
RUN dotnet test ./PlantHere.Test/*.csproj

# .NET Core Build and Publish
RUN dotnet publish ./PlantHere/PlantHere.WebAPI.csproj -o /publish/

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://*:5001
ENTRYPOINT ["dotnet", "PlantHere.WebAPI.dll"]