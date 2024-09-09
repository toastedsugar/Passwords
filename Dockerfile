# Use the official ASP.NET core runtime image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official build image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj and restore all of the nugets
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining application files
COPY . ./
RUN dotnet publish -c Release -o out

# Set the default working directory
WORKDIR /src

# Build the app
RUN dotnet build -c Debug -o /app/build

# Use a separate image stage to run the application
FROM build AS development
WORKDIR /src
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]
