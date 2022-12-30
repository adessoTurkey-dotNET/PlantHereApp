#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
COPY ./AuthServer.Application/AuthServer.Application.csproj ./AuthServer.Application/
COPY ./AuthServer.Domain/AuthServer.Domain.csproj ./AuthServer.Domain/
COPY ./AuthServer.API/AuthServer.API.csproj ./AuthServer.API/
COPY ./AuthServer.Infrastructure/AuthServer.Infrastructure.csproj ./AuthServer.Infrastructure/
COPY ./AuthServer.Persistence/AuthServer.Persistence.csproj ./AuthServer.Persistence/

# .NET Core Restore
RUN dotnet restore ./AuthServer.API/AuthServer.API.csproj

# Copy All Files
COPY . ./

# .NET Core Build and Publish
RUN dotnet publish ./AuthServer.API/AuthServer.API.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://*:4500
ENTRYPOINT ["dotnet", "AuthServer.API.dll"]