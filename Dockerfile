#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ["NuGet.Config", "."]
COPY ["EFSoft.Inventory.Api/EFSoft.Inventory.Api.csproj", "EFSoft.Inventory.Api/"]
COPY ["EFSoft.Inventory.Application/EFSoft.Inventory.Application.csproj", "EFSoft.Inventory.Application/"]
COPY ["EFSoft.Inventory.Domain/EFSoft.Inventory.Domain.csproj", "EFSoft.Inventory.Domain/"]
COPY ["EFSoft.Inventory.Infrastructure/EFSoft.Inventory.Infrastructure.csproj", "EFSoft.Inventory.Infrastructure/"]

ARG NUGET_PASSWORD
RUN apk add --update sed 
RUN sed -i "s|</configuration>|<packageSourceCredentials><emilfilip3><add key=\"Username\" value=\"emilfilip3\" /><add key=\"ClearTextPassword\" value=\"${NUGET_PASSWORD}\" /></emilfilip3></packageSourceCredentials></configuration>|" NuGet.Config

RUN dotnet restore "EFSoft.Inventory.Api/EFSoft.Inventory.Api.csproj" --configfile NuGet.Config

COPY . .
WORKDIR "/src/EFSoft.Inventory.Api"
RUN dotnet build "EFSoft.Inventory.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EFSoft.Inventory.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFSoft.Inventory.Api.dll"]
