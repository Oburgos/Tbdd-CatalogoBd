#FROM microsoft/aspnetcore-build:2.0 AS build-env
#WORKDIR /app
#
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#

#    "DefaultConnection": "Server=DESKTOP-DAD17PU;Database=CatalogoDeServidores;Trusted_Connection=True"

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY /out .
ENTRYPOINT ["dotnet", "ServerCatalogStudio.Api.dll"]