#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ENV Husky=0

WORKDIR /src
COPY ["src/FlbCleanTemplate/FlbCleanTemplate.csproj", "src/FlbCleanTemplate/"]
COPY ["mocks/FlbCleanTemplate.WeatherService.Mock/FlbCleanTemplate.WeatherService.Mock.csproj", "mocks/FlbCleanTemplate.WeatherService.Mock/"]
COPY ["src/FlbCleanTemplate.Application/FlbCleanTemplate.Application.csproj", "src/FlbCleanTemplate.Application/"]
COPY ["src/FlbCleanTemplate.Domain/FlbCleanTemplate.Domain.csproj", "src/FlbCleanTemplate.Domain/"]
RUN dotnet restore "src/FlbCleanTemplate/FlbCleanTemplate.csproj"
COPY . .
WORKDIR "/src/src/FlbCleanTemplate"
RUN dotnet build "FlbCleanTemplate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlbCleanTemplate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlbCleanTemplate.dll"]