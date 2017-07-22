
# Use an official aspnetcore runtime as a parent image
FROM microsoft/aspnetcore-build:1.1 AS build-env
# Set the working directory to /app
WORKDIR /app

# copy all csproj files and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build (source .) (destination ./)
COPY . ./  
RUN dotnet publish -c Release -o out

# Define environment variable
#ENV NAME World

# build runtime image
FROM microsoft/aspnetcore:1.1
WORKDIR /app
# Make port 80 available to the world outside this container
EXPOSE 80
#COPY ${source:-obj/Docker/publish} .
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MW.API.dll"]