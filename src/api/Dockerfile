FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /App

COPY *.csproj ./

RUN export DOTNET_CONNECTION_STRING="Server=127.0.0.1;Database=tryitter_db;User=SA;Password=Password12!;TrustServerCertificate=true"

RUN docker-compose up

RUN dotnet restore

RUN docker ef database update

COPY . ./

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /App

EXPOSE 80

COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "run"]