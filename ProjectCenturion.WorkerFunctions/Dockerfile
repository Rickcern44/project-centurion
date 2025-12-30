FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjectCenturion.WorkerFunctions/ProjectCenturion.WorkerFunctions.csproj", "ProjectCenturion.WorkerFunctions/"]
RUN dotnet restore "ProjectCenturion.WorkerFunctions/ProjectCenturion.WorkerFunctions.csproj"
COPY . .
WORKDIR "/src/ProjectCenturion.WorkerFunctions"
RUN dotnet build "./ProjectCenturion.WorkerFunctions.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectCenturion.WorkerFunctions.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectCenturion.WorkerFunctions.dll"]
