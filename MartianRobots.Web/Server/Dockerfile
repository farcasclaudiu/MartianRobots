#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MartianRobots.Web/Server/MartianRobots.Web.Server.csproj", "MartianRobots.Web/Server/"]
COPY ["MartianRobotsSolver/MartianRobotsSolver.csproj", "MartianRobotsSolver/"]
COPY ["MartianRobots.Web/Shared/MartianRobots.Web.Shared.csproj", "MartianRobots.Web/Shared/"]
COPY ["MartianRobots.Web/Client/MartianRobots.Web.Client.csproj", "MartianRobots.Web/Client/"]
RUN dotnet restore "MartianRobots.Web/Server/MartianRobots.Web.Server.csproj"
COPY . .
WORKDIR "/src/MartianRobots.Web/Server"
RUN dotnet build "MartianRobots.Web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MartianRobots.Web.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MartianRobots.Web.Server.dll"]