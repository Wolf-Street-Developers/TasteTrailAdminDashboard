FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY TasteTrailUserManager/src/TasteTrailUserManager.Api/*.csproj TasteTrailUserManager/src/TasteTrailUserManager.Api/
COPY TasteTrailUserManager/src/TasteTrailUserManager.Infrastructure/*.csproj TasteTrailUserManager/src/TasteTrailUserManager.Infrastructure/
COPY TasteTrailUserManager/src/TasteTrailUserManager.Core/*.csproj TasteTrailUserManager/src/TasteTrailUserManager.Core/

COPY . .

RUN dotnet publish TasteTrailUserManager/src/TasteTrailUserManager.Api/*.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "TasteTrailUserManager.Api.dll" ]