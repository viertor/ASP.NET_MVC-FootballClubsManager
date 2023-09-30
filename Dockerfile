FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN apt-get update
RUN apt-get install -y curl
   
WORKDIR /source


COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app ./


RUN apt-get update
RUN apt-get install -y curl
ENTRYPOINT ["dotnet", "FootballClubsManager.dll"]
