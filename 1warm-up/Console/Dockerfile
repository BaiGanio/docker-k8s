FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Console

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release. This command will compiles the app into the out folder.
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /Console
COPY --from=build-env /Console/out .
ENTRYPOINT ["dotnet", "Console.Docker.dll"]