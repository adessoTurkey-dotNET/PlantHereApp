#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
COPY ./AuthServer.Application/*.csproj ./AuthServer.Application/
COPY ./AuthServer.Domain/*.csproj ./AuthServer.Domain/
COPY ./AuthServer.API/*.csproj ./AuthServer.API/
COPY ./AuthServer.Infrastructure/*.csproj ./AuthServer.Infrastructure/
COPY ./AuthServer.Persistence/*.csproj ./AuthServer.Persistence/
COPY ./AuthServer.API/temp-keys .
COPY *.sln .

# .NET Core Restore
RUN dotnet restore

# Copy All Files
COPY . .

# .NET Core Build and Publish
RUN dotnet publish ./AuthServer.API/AuthServer.API.csproj -o /publish/

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base 
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://*:4500
ENTRYPOINT ["dotnet", "AuthServer.API.dll"]