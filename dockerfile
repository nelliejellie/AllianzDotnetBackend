# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj and .sln files to the container
COPY *.sln .
COPY AllianzInsuranceBackend.Presentation/*.csproj ./AllianzInsuranceBackend.Presentation/
COPY AllianzInsuranceBackend.Application/*.csproj ./AllianzInsuranceBackend.Application/
COPY AllianzInsuranceBackend.Infrastructure/*.csproj ./AllianzInsuranceBackend.Infrastructure/
COPY AllianzInsuranceBackend.Domain/*.csproj ./AllianzInsuranceBackend.Domain/


# Restore NuGet packages for all projects
RUN dotnet restore

# Copy the rest of the source code to the container
COPY . .

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o /app/publish --no-restore

# Use the official ASP.NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose port 80 for the API
EXPOSE 80

# Define environment variables if needed
# ENV ASPNETCORE_ENVIRONMENT=Production

# Start the API when the container starts
ENTRYPOINT ["dotnet", "AllianzInsuranceBackend.Presentation.dll"]