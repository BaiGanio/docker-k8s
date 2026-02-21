FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /C1Boss

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release. This command will compiles the app into the out folder.
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS runtime
WORKDIR /C1Boss
COPY --from=build-env /C1Boss/out .
ENTRYPOINT ["dotnet", "C1Boss.Docker.dll"]