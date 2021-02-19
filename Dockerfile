FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base 

WORKDIR /app 
FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build 

WORKDIR /src 
COPY . . 
FROM build AS publish 
RUN dotnet publish "eKlinika.WebAPI" -c Release -o /app
 FROM base AS final 
WORKDIR /app 
COPY --from=publish /app . 

ENTRYPOINT ["dotnet", "eKlinika.WebAPI.dll"]