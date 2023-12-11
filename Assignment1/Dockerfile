FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /app

COPY *.sln .
COPY Assignment1/*.csproj ./Assignment1/
RUN dotnet restore

COPY Assignment1/. ./Assignment1/
WORKDIR /app/Assignment1
RUN dotnet publish -c Release -o /out --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime
WORKDIR /app
COPY --from=build /out ./
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "Assignment1.dll"]
