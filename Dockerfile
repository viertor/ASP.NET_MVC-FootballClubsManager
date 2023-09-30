FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN apt-get update
RUN apt-get install -y curl
   
WORKDIR /source

COPY . .
RUN dotnet publish -c release -o /app

WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "FootballClubsManager.dll"]
