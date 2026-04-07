# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /repo

COPY NetCoreContosoUniversityApp.slnx ./
COPY src/ src/

RUN dotnet restore NetCoreContosoUniversityApp.slnx

RUN dotnet publish src/NetCoreContosoUniversityApp.Web.MVC/NetCoreContosoUniversityApp.Web.MVC.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "NetCoreContosoUniversityApp.Web.MVC.dll"]
