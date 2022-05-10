FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Inventory.Presentations.Api/Inventory.Presentations.Api.csproj", "Inventory.Presentations.Api/"]
RUN dotnet restore "Inventory.Presentations.Api/Inventory.Presentations.Api.csproj"
COPY . .
WORKDIR "/src/Inventory.Presentations.Api"
RUN dotnet build "Inventory.Presentations.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.Presentations.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.Presentations.Api.dll"]
