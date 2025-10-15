# -------- Build Stage --------
# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy remaining source code
COPY . ./

# Publish the app to /app/publish
RUN dotnet publish -c Release -o /app/publish

# -------- Runtime Stage --------
# Use official .NET ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose the port (Render will use $PORT)
EXPOSE 10000

# Set environment variable for URLs
ENV ASPNETCORE_URLS=http://+:10000

# Start the app
ENTRYPOINT ["dotnet", "RecipeBook.Web.dll"]
