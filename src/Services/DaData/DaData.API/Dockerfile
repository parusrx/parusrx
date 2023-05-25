FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build

# Install Native AOT build prerequisites
RUN apk add clang build-base zlib-dev

WORKDIR /src

COPY . .
RUN dotnet publish "/src/Services/DaData/DaData.API/DaData.API.csproj" -o /app/publish

FROM base AS publish
WORKDIR /app
COPY --from=build /app/publish .
RUN rm *.pdb

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
USER $APP_UID
HEALTHCHECK CMD wget -qO- -t1 http://localhost:8080/health || exit 1
ENTRYPOINT ["./DaData.API"]