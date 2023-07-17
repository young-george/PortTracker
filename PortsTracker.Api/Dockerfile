FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PortsTracker.Api/PortsTracker.Api.csproj", "PortsTracker.Api/"]
RUN dotnet restore "PortsTracker.Api/PortsTracker.Api.csproj"
COPY . .
WORKDIR "/src/PortsTracker.Api"
RUN dotnet build "PortsTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortsTracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortsTracker.Api.dll"]
