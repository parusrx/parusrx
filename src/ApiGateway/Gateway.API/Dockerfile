FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build
WORKDIR /src

COPY . .
RUN dotnet publish "/src/ApiGateway/Gateway.API/Gateway.API.csproj" -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS publish
WORKDIR /app
COPY --from=build /app/publish .
RUN rm *.pdb

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]
EXPOSE 8080