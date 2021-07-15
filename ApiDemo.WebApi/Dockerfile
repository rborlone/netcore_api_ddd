#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ApiDemo.Infra/*.csproj ./ApiDemo.Infra/
COPY ApiDemo.Domain/*.csproj ./ApiDemo.Domain/
COPY ApiDemo.WebApi/*.csproj ./ApiDemo.WebApi/

RUN dotnet restore

COPY . .

WORKDIR /src/ApiDemo.Infra
RUN dotnet build  "ApiDemo.Infra.csproj" -c Release -o /app/build

WORKDIR /src/ApiDemo.Domain
RUN dotnet build "ApiDemo.Domain.csproj" -c Debug -o /app/build

WORKDIR /src/ApiDemo.WebApi
RUN dotnet build "ApiDemo.WebApi.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ApiDemo.WebApi.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ApiDemo.WebApi.dll"]


#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
#WORKDIR /app
#
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#EXPOSE 80
#EXPOSE 443
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "ApiDemo.WebApi.dll"]
#
#
#










#
#
#
#
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY *.csproj ./
#RUN dotnet restore
##COPY ["ApiDemo.WebApi/ApiDemo.WebApi.csproj", "ApiDemo.WebApi/"]
##RUN dotnet restore "/ApiDemo.WebApi/ApiDemo.WebApi.csproj"
##COPY . .
#COPY . ./
#RUN dotnet publish -c Release -o out
##WORKDIR "/src/ApiDemo.WebApi"
##RUN dotnet build "ApiDemo.WebApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app/publish
##RUN dotnet publish "ApiDemo.WebApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ApiDemo.WebApi.dll"]