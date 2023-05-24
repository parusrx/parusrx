FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build
WORKDIR /src
COPY ["Common/EventBus/EventBus.csproj", "Common/EventBus/"]
COPY ["Common/MultiTenancy/MultiTenancy/MultiTenancy.csproj", "Common/MultiTenancy/MultiTenancy/"]
COPY ["Common/MultiTenancy/MultiTenancy.Tests/MultiTenancy.Tests.csproj", "Common/MultiTenancy/MultiTenancy.Tests/"]
COPY ["Common/Storage/Storage/Storage.csproj", "Common/Storage/Storage/"]
COPY ["Common/Storage/Storage.Oracle/Storage.Oracle.csproj", "Common/Storage/Storage.Oracle/"]
COPY ["Common/Storage/Storage.Postgres/Storage.Postgres.csproj", "Common/Storage/Storage.Postgres/"]
COPY ["Common/Xml/Xml/Xml.csproj", "Common/Xml/Xml/"]
COPY ["Common/Xml/Xml.Tests/Xml.Tests.csproj", "Common/Xml/Xml.Tests/"]
COPY ["ApiGateway/Gateway.API/Gateway.API.csproj", "ApiGateway/Gateway.API/"]
COPY ["ApiGateway/Gateway.UnitTests/Gateway.UnitTests.csproj", "ApiGateway/Gateway.UnitTests/"]
COPY ["ApiGateway/Gateway.FunctionalTests/Gateway.FunctionalTests.csproj", "ApiGateway/Gateway.FunctionalTests/"]
COPY ["Services/DaData/DaData.API/DaData.API.csproj", "Services/DaData/DaData.API/"]
COPY ["Services/DaData/DaData.API.UnitTests/DaData.API.UnitTests.csproj", "Services/DaData/DaData.API.UnitTests/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["ParusRx.sln", "./"]
RUN dotnet restore "ParusRx.sln"

COPY . .
WORKDIR "/src/ApiGateway/Gateway.API"

FROM build AS publish
RUN dotnet publish --no-restore "Gateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]