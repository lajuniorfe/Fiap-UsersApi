
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore Users.Api/Users.Api.csproj

RUN dotnet build Users.Api/Users.Api.csproj \
    -c Release \
    -o /app/build \
    --no-restore

FROM build AS publish

RUN dotnet publish Users.Api/Users.Api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Users.Api.dll"]
