FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjectCenturion.Leads/ProjectCenturion.Leads.csproj", "ProjectCenturion.Leads/"]
COPY ["ProjectCenturion.Shared/ProjectCenturion.Shared.csproj", "ProjectCenturion.Shared/"]
RUN dotnet restore "ProjectCenturion.Leads/ProjectCenturion.Leads.csproj"
COPY . .
WORKDIR "/src/ProjectCenturion.Leads"
RUN dotnet build "./ProjectCenturion.Leads.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectCenturion.Leads.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectCenturion.Leads.dll"]
