# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and restore
COPY ../../StudentManager.sln ./
COPY ../../src/StudentManager.*/*.csproj ./src/
RUN for file in src/*.csproj; do dotnet restore "$file"; done

# Copy all source
COPY ../../src ./src
WORKDIR /app/src/StudentManager.API
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
EXPOSE 80
ENTRYPOINT ["dotnet", "StudentManager.API.dll"]
