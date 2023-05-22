#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["Common/EventBus/src/ParusRx.EventBus.csproj", "Common/EventBus/src/"]
COPY ["Common/MultiTenancy/src/ParusRx.MultiTenancy.csproj", "Common/MultiTenancy/src/"]
COPY ["Common/MultiTenancy/tests/ParusRx.MultiTenancy.Tests.csproj", "Common/MultiTenancy/tests/"]
COPY ["Common/Storage/Abstractions/src/ParusRx.Storage.Abstractions.csproj", "Common/Storage/Abstractions/src/"]
COPY ["Common/Storage/Oracle/src/ParusRx.Storage.Oracle.csproj", "Common/Storage/Oracle/src/"]
COPY ["Common/Storage/Postgres/src/ParusRx.Storage.Postgres.csproj", "Common/Storage/Postgres/src/"]
COPY ["Common/Xml/src/ParusRx.Xml.csproj", "Common/Xml/src/"]
COPY ["Common/Xml/tests/ParusRx.Xml.Tests.csproj", "Common/Xml/tests/"]
COPY ["ApiGateway/src/ParusRx.ApiGateway.csproj", "ApiGateway/src/"]
COPY ["ApiGateway/tests/ApiGateway.UnitTests/ParusRx.ApiGateway.UnitTests.csproj", "ApiGateway/tests/ApiGateway.UnitTests/"]
COPY ["ApiGateway/tests/ApiGateway.FunctionalTests/ParusRx.ApiGateway.FunctionalTests.csproj", "ApiGateway/tests/ApiGateway.FunctionalTests/"]
COPY ["Services/DaData/DaData.Api/ParusRx.DaData.Api.csproj", "Services/DaData/DaData.Api/"]
COPY ["Services/DaData/DaData.Api.UnitTests/ParusRx.DaData.Api.UnitTests.csproj", "Services/DaData/DaData.Api.UnitTests/"]
COPY ["docker-compose.dcproj", "./"]
COPY ["ParusRx.sln", "./"]
RUN dotnet restore "ParusRx.sln"
COPY . .
WORKDIR "/src/Services/DaData/DaData.Api"
RUN dotnet build "ParusRx.DaData.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParusRx.DaData.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRx.DaData.Api.dll"]