FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

ADD tools /tmp/tools 
RUN cd /tmp/tools && \
    tar -xzf linux-amd64_deb.tgz && \
    linux-amd64_deb/install.sh && \
    cd /bin && \
    ln -s /opt/cprocsp/bin/amd64/certmgr && \
    ln -s /opt/cprocsp/bin/amd64/cpverify && \
    ln -s /opt/cprocsp/bin/amd64/cryptcp && \
    ln -s /opt/cprocsp/bin/amd64/csptest && \
    ln -s /opt/cprocsp/bin/amd64/csptestf && \
    ln -s /opt/cprocsp/bin/amd64/der2xer && \
    ln -s /opt/cprocsp/bin/amd64/inittst && \
    ln -s /opt/cprocsp/bin/amd64/wipefile && \
    ln -s /opt/cprocsp/sbin/amd64/cpconfig && \
    rm -rf /tmp/tools

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ".nuget/packages/cryptopro.security.cryptography.2024.11.19.nupkg" ".nuget/packages/cryptopro.security.cryptography.2024.11.19.nupkg"
COPY ".nuget/packages/cryptopro.security.cryptography.xml.2024.11.19.nupkg" ".nuget/packages/cryptopro.security.cryptography.xml.2024.11.19.nupkg"
COPY "src/Services/Egisz/Ips/Ips.IdentityProvider.API/Ips.IdentityProvider.API.csproj" "src/Services/Egisz/Ips/Ips.IdentityProvider.API/Ips.IdentityProvider.API.csproj"

COPY . .
WORKDIR /src
RUN dotnet restore "src/Services/Egisz/Ips/Ips.IdentityProvider.API/Ips.IdentityProvider.API.csproj"

WORKDIR /src
RUN dotnet build "src/Services/Egisz/Ips/Ips.IdentityProvider.API/Ips.IdentityProvider.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
WORKDIR /src
RUN dotnet publish "src/Services/Egisz/Ips/Ips.IdentityProvider.API/Ips.IdentityProvider.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD wget -q0- -t1 http://localhost:80/health || exit 1
ENTRYPOINT ["dotnet", "Ips.IdentityProvider.API.dll"]
