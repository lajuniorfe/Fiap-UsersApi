#FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
#WORKDIR /src
#
#
#COPY ["Users.Api.csproj", "."]
#RUN dotnet restore "Users.Api.csproj"
#
#COPY . .
#RUN dotnet build "Users.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Users.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
#WORKDIR /app
#
#COPY --from=publish /app/publish .
#
#ENTRYPOINT ["dotnet", "Users.Api.dll"]


FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copia TUDO (solution inteira)
COPY . .



# build do projeto correto
RUN dotnet build Users.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Users.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Users.Api.dll"]