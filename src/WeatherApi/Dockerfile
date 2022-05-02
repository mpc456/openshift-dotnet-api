#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WeatherApi/WeatherApi.csproj", "src/WeatherApi/"]
RUN dotnet restore "src/WeatherApi/WeatherApi.csproj"
COPY . .
WORKDIR "/src/src/WeatherApi"
RUN dotnet build "WeatherApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherApi.dll"]