# Встановлення базового образу
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Lab1-2/Lab1-2.csproj"
RUN dotnet build "Lab1-2/Lab1-2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab1-2/Lab1-2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab1-2.dll"]
