#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BloodDonation.Database.Api/BloodDonation.Database.Api.csproj", "BloodDonation.Database.Api/"]
RUN dotnet restore "./BloodDonation.Database.Api/./BloodDonation.Database.Api.csproj"
COPY . .
WORKDIR "/src/BloodDonation.Database.Api"
RUN dotnet build "./BloodDonation.Database.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BloodDonation.Database.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BloodDonation.Database.Api.dll"]