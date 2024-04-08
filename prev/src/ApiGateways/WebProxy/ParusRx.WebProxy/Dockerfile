#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=6.0
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src
COPY ["src/ApiGateways/WebProxy/ParusRx.WebProxy/ParusRx.WebProxy.csproj", "src/ApiGateways/WebProxy/ParusRx.WebProxy/"]
RUN dotnet restore "src/ApiGateways/WebProxy/ParusRx.WebProxy/ParusRx.WebProxy.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/WebProxy/ParusRx.WebProxy"
RUN dotnet build "ParusRx.WebProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParusRx.WebProxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParusRx.WebProxy.dll"]