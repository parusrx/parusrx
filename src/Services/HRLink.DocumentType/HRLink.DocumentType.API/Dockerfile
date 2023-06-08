FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build

# Install Native AOT build prerequisites
RUN apk add clang build-base zlib-dev

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    SuppressNETCoreSdkPreviewMessage=true

WORKDIR /src

COPY . .
RUN dotnet publish "/src/Services/HRLink.DocumentType/HRLink.DocumentType.API/HRLink.DocumentType.API.csproj" -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview-alpine AS publish
WORKDIR /app
COPY --from=build /app/publish .
RUN rm *.pdb
RUN rm *.dbg

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-preview-alpine
WORKDIR /app
COPY --from=publish /app .
USER $APP_UID
HEALTHCHECK CMD wget -q0- -t1 http://localhost:8080/health || exit 1
ENTRYPOINT ["./HRLink.DocumentType.API"]