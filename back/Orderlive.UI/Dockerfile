#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Orderlive.UI/OrderLive.UI.csproj", "Orderlive.UI/"]
COPY ["OrderLive.App/OrderLive.App.csproj", "OrderLive.App/"]
COPY ["OrderLive.Domain/OrderLive.Domain.csproj", "OrderLive.Domain/"]
COPY ["OrderLive.Infrastructure/OrderLive.Infrastructure.csproj", "OrderLive.Infrastructure/"]
RUN dotnet restore "./Orderlive.UI/OrderLive.UI.csproj"
COPY . .
WORKDIR "/src/Orderlive.UI"
RUN dotnet build "./OrderLive.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderLive.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderLive.UI.dll"]