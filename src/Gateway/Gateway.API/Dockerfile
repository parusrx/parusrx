FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build
WORKDIR /src

COPY . .
RUN dotnet publish "src/Gateway/Gateway.API/Gateway.API.csproj" -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine
WORKDIR /app
COPY --from=build /app/publish .
USER $APP_UID
HEALTHCHECK CMD wget -qO- -t1 http://localhost:8080/health || exit 1
ENTRYPOINT ["./Gateway.API"]