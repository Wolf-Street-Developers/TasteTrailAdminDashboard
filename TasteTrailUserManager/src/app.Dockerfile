FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ./TasteTrailUserManager.Api/*.csproj ./TasteTrailUserManager.Api/
COPY ./TasteTrailUserManager.Infrastructure/*.csproj ./TasteTrailUserManager.Infrastructure/
COPY ./TasteTrailUserManager.Core/*.csproj ./TasteTrailUserManager.Core/

COPY . .

RUN dotnet publish TasteTrailUserManager.Api/*.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "TasteTrailUserManager.Api.dll" ]