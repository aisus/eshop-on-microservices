# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY /Shop.Gateway.Web.Api/*.csproj ./Shop.Gateway.Web.Api/
RUN dotnet restore

# copy everything else and build app
COPY /Shop.Gateway.Web.Api/ ./Shop.Gateway.Web.Api/
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Shop.Gateway.Web.Api.dll"]