#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=6.0
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
COPY ["src/Web/ParusRx.HealthCheck/ParusRx.HealthCheck.csproj", "src/Web/ParusRx.HealthCheck/"]
RUN dotnet restore "src/Web/ParusRx.HealthCheck/ParusRx.HealthCheck.csproj"
COPY . .
WORKDIR "/src/src/Web/ParusRx.HealthCheck"
RUN dotnet build "ParusRx.HealthCheck.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParusRx.HealthCheck.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRx.HealthCheck.dll"]