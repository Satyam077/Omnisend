# ===========================
# Base image for runtime
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ===========================
# Build stage
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the API project file first and restore dependencies
COPY ["Omnisend.Server.csproj", "./"]
RUN dotnet restore "Omnisend.Server.csproj"

# Copy the rest of the project
COPY . .

# Build the API
WORKDIR "/src/Omnisend.Server"
RUN dotnet build "Omnisend.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ===========================
# Publish stage
# ===========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Omnisend.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===========================
# Final stage
# ===========================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Make sure your app binds to Render's port
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "Omnisend.Server.dll"]
