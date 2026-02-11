# Use official SQL Server image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set required environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=P@ssw0rd

# Expose SQL Server port
EXPOSE 1433

# Default command to run SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
