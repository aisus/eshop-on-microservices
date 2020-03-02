# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY /Shop.Orders.Api/*.csproj ./Shop.Orders.Api/
COPY /Shop.Orders.Domain/*.csproj ./Shop.Orders.Domain/
COPY /Shop.Orders.DataAccess/*.csproj ./Shop.Orders.DataAccess/
RUN dotnet restore

# copy everything else and build app
COPY /Shop.Orders.Api/. ./Shop.Orders.Api/
COPY /Shop.Orders.Domain/. ./Shop.Orders.Domain/
COPY /Shop.Orders.DataAccess/. ./Shop.Orders.DataAccess/
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Shop.Orders.Api.dll"]