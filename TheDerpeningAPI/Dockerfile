#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 7568

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TheDerpeningAPI/TheDerpeningAPI.csproj", "TheDerpeningAPI/"]
COPY ["TheDerpening/TheDerpening.csproj", "TheDerpening/"]
RUN dotnet restore "./TheDerpeningAPI/TheDerpeningAPI.csproj"
COPY . .
WORKDIR "/src/TheDerpeningAPI"
RUN dotnet build "./TheDerpeningAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TheDerpeningAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheDerpeningAPI.dll"]