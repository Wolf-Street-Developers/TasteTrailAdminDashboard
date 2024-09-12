FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ./TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Api/*.csproj .TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Api/
COPY ./TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Infrastructure/*.csproj .TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Infrastructure/
COPY ./TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Core/*.csproj .TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Core/

COPY . .

RUN dotnet publish TasteTrailAdminDashboard/src/TasteTrailAdminDashboard.Api/*.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "TasteTrailAdminDashboard.Api.dll" ]