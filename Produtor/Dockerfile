FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Produtor/Produtor.csproj", "Produtor/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "./Produtor/Produtor.csproj"
COPY . .
WORKDIR "/src/Produtor"
RUN dotnet build "./Produtor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Produtor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "Produtor.dll"]
