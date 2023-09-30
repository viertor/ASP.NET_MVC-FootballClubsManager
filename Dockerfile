FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN apt-get update \
    && apt-get install -y curl jq 
    
WORKDIR /source

COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "FootballClubsManager.dll"]
