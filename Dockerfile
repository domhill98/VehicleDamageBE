FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VehicleDamage_BackEnd/VehicleDamage_BackEnd.csproj", "VehicleDamage_BackEnd/"]
RUN dotnet restore "VehicleDamage_BackEnd/VehicleDamage_BackEnd.csproj"
COPY . .
WORKDIR "/src/VehicleDamage_BackEnd"
RUN dotnet build "VehicleDamage_BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleDamage_BackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleDamage_BackEnd.dll"]
