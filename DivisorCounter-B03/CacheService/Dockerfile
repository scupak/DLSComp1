FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CacheService/CacheService.csproj", "CacheService/"]
RUN dotnet restore "CacheService/CacheService.csproj"
COPY . .
WORKDIR "/src/CacheService"
RUN dotnet build "CacheService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CacheService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CacheService.dll"]
