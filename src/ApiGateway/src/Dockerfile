FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["SDK/EventBus/src/ParusRx.EventBus.csproj", "SDK/EventBus/src/"]
COPY ["SDK/MultiTenancy/src/ParusRx.MultiTenancy.csproj", "SDK/MultiTenancy/src/"]
COPY ["SDK/MultiTenancy/test/ParusRx.MultiTenancy.Tests.csproj", "SDK/MultiTenancy/test/"]
COPY ["SDK/Storage/Abstractions/src/ParusRx.Storage.Abstractions.csproj", "SDK/Storage/Abstractions/src/"]
COPY ["SDK/Storage/Oracle/src/ParusRx.Storage.Oracle.csproj", "SDK/Storage/Oracle/src/"]
COPY ["SDK/Storage/Postgres/src/ParusRx.Storage.Postgres.csproj", "SDK/Storage/Postgres/src/"]
COPY ["SDK/XML/src/ParusRx.Xml.csproj", "SDK/XML/src/"]
COPY ["SDK/XML/test/ParusRx.Xml.Tests.csproj", "SDK/XML/test/"]
COPY ["ApiGateway/src/ParusRx.ApiGateway.csproj", "ApiGateway/src/"]
COPY ["ApiGateway/tests/ApiGateway.UnitTests/ParusRx.ApiGateway.UnitTests.csproj", "ApiGateway/tests/ApiGateway.UnitTests/"]
COPY ["ApiGateway/tests/ApiGateway.FunctionalTests/ParusRx.ApiGateway.FunctionalTests.csproj", "ApiGateway/tests/ApiGateway.FunctionalTests/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["ParusRx.sln", "./"]
RUN dotnet restore "ParusRx.sln"

COPY . .
WORKDIR "/src/ApiGateway/src"

FROM build AS publish
RUN dotnet publish --no-restore "ParusRx.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRx.ApiGateway.dll"]