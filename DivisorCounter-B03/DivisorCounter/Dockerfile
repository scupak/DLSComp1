FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DivisorCounter/DivisorCounter.csproj", "DivisorCounter/"]
RUN dotnet restore "DivisorCounter/DivisorCounter.csproj"
COPY . .
WORKDIR "/src/DivisorCounter"
RUN dotnet build "DivisorCounter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DivisorCounter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DivisorCounter.dll"]
