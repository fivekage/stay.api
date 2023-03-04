#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 443 8080
ENV ASPNETCORE_URLS=http://*:8080

# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY stay.api/*.csproj stay.api/
COPY stay.application/*.csproj stay.application/
COPY stay.domain/*.csproj stay.domain/
COPY stay.infrastructure/*.csproj stay.infrastructure/

RUN dotnet restore stay.api/stay.api.csproj

COPY stay.api/ stay.api/
COPY stay.application/ stay.application/
COPY stay.domain/ stay.domain/
COPY stay.infrastructure/ stay.infrastructure/

WORKDIR /src/stay.api
RUN dotnet build -c release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish -r linux-x64

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "stay.api.dll"]