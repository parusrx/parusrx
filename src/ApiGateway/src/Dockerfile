FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["SDK/EventBus/src/ParusRX.EventBus.csproj", "SDK/EventBus/src/"]
COPY ["SDK/MultiTenancy/src/ParusRX.MultiTenancy.csproj", "SDK/MultiTenancy/src/"]
COPY ["SDK/MultiTenancy/test/ParusRX.MultiTenancy.Tests.csproj", "SDK/MultiTenancy/test/"]
COPY ["SDK/Storage/Abstractions/src/ParusRX.Storage.Abstractions.csproj", "SDK/Storage/Abstractions/src/"]
COPY ["SDK/Storage/Oracle/src/ParusRX.Storage.Oracle.csproj", "SDK/Storage/Oracle/src/"]
COPY ["SDK/Storage/Postgres/src/ParusRX.Storage.Postgres.csproj", "SDK/Storage/Postgres/src/"]
COPY ["SDK/XML/src/ParusRX.Xml.csproj", "SDK/XML/src/"]
COPY ["SDK/XML/test/ParusRX.Xml.Tests.csproj", "SDK/XML/test/"]
COPY ["ApiGateway/src/ParusRX.ApiGateway.csproj", "ApiGateway/src/"]
COPY ["ApiGateway/tests/ApiGateway.UnitTests/ParusRX.ApiGateway.UnitTests.csproj", "ApiGateway/tests/ApiGateway.UnitTests/"]
COPY ["ApiGateway/tests/ApiGateway.FunctionalTests/ParusRX.ApiGateway.FunctionalTests.csproj", "ApiGateway/tests/ApiGateway.FunctionalTests/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["ParusRX.sln", "./"]
RUN dotnet restore "ParusRX.sln"

COPY . .
WORKDIR "/src/ApiGateway/src"
#RUN dotnet build "ParusRX.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore "ParusRX.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRX.ApiGateway.dll"]