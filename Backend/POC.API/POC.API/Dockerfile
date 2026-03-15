FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["POC.API/POC.API.csproj", "POC.API/"]
RUN dotnet restore "./POC.API/POC.API.csproj"

COPY . .
WORKDIR "/src/POC.API"

RUN dotnet publish "POC.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "POC.API.dll"]