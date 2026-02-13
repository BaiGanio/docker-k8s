FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /ConsoleConsumer

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release. This command will compiles the app into the out folder.
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /ConsoleConsumer
COPY --from=build-env /ConsoleConsumer/out .
ENTRYPOINT ["dotnet", "Console.Docker.dll"]