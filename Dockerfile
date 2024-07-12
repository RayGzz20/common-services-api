# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 2222

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AppCommonServices.WebAPI/AppCommonServices.WebAPI.csproj", "AppCommonServices.WebAPI/"]
COPY ["AppCommonServices.Infrastructure/AppCommonServices.Infrastructure.csproj", "AppCommonServices.Infrastructure/"]
COPY ["AppCommonServices.Domain/AppCommonServices.Domain.csproj", "AppCommonServices.Domain/"]
COPY ["AppCommonServices.Application/AppCommonServices.Application.csproj", "AppCommonServices.Application/"]
RUN dotnet restore "./AppCommonServices.WebAPI/AppCommonServices.WebAPI.csproj"
COPY . .
WORKDIR "/src/AppCommonServices.WebAPI"
RUN dotnet build "./AppCommonServices.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AppCommonServices.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

# Instalar paquetes necesarios y configurar el entorno
USER root
RUN apt-get update && \
    apt-get install -y supervisor openssh-server nano && \
    echo "root:Docker!" | chpasswd && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

RUN mkdir -p /var/log/supervisor /run/sshd

# Configuración SSH y Supervisor
COPY sshd_config /etc/ssh/
ADD supervisord.conf /etc/supervisord.conf
COPY docker-entrypoint.sh /usr/local/bin/
RUN chmod -R +x /usr/local/bin

# Copiar los archivos publicados de la aplicación
COPY --from=publish /app/publish .

# Volver al usuario original
USER app

ENTRYPOINT ["dotnet", "AppCommonServices.WebAPI.dll"]
CMD ["supervisord", "--nodaemon", "--configuration", "/etc/supervisord.conf"]

