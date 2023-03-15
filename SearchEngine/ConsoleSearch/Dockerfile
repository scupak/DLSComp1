FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsoleSearch/ConsoleSearch.csproj", "ConsoleSearch/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "ConsoleSearch/ConsoleSearch.csproj"
COPY . .
WORKDIR "/src/ConsoleSearch"
RUN dotnet build "ConsoleSearch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleSearch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleSearch.dll"]
