# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# restore
COPY ["FirstAPI/FirstAPI.csproj", "./"]
RUN dotnet restore "FirstAPI.csproj"

# build
COPY ["FirstAPI", "./"]
RUN dotnet build "FirstAPI.csproj" -c Release -o /app/build

# Stage 2: Publish Stage
FROM build AS publish
RUN dotnet publish "FirstAPI.csproj" -c Release -o /app/publish

# Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5002
EXPOSE 5002
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstAPI.dll"]