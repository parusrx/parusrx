#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=6.0
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
COPY ["src/BuildingBlocks/Stores/ParusRx.Stores.Oracle/ParusRx.Stores.Oracle.csproj", "src/BuildingBlocks/Stores/ParusRx.Stores.Oracle/"]
COPY ["src/BuildingBlocks/Stores/ParusRx.Stores.Abstractions/ParusRx.Stores.Abstractions.csproj", "src/BuildingBlocks/Stores/ParusRx.Stores.Abstractions/"]
COPY ["src/BuildingBlocks/Stores/ParusRx.Stores.Postgres/ParusRx.Stores.Postgres.csproj", "src/BuildingBlocks/Stores/ParusRx.Stores.Postgres/"]
COPY ["src/BuildingBlocks/EventBus/ParusRx.EventBus/ParusRx.EventBus.csproj", "src/BuildingBlocks/EventBus/ParusRx.EventBus/"]
COPY ["src/BuildingBlocks/Extensions/ParusRx.Extensions/ParusRx.Extensions.csproj", "src/BuildingBlocks/Extensions/ParusRx.Extensions/"]
COPY ["src/Services/eArchive/ParusRx.EArchive.Api/ParusRx.EArchive.Api.csproj", "src/Services/eArchive/ParusRx.EArchive.Api/"]
RUN dotnet restore "src/Services/eArchive/ParusRx.EArchive.Api/ParusRx.EArchive.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/eArchive/ParusRx.EArchive.Api"
RUN dotnet build "ParusRx.EArchive.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParusRx.EArchive.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRx.EArchive.Api.dll"]