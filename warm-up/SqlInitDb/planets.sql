-- Create the database only if it does NOT already exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Planets')
BEGIN
    CREATE DATABASE Planets
END
GO

-- Switch to the database
USE Planets
GO

-- Create the main table if it does not exist
IF OBJECT_ID('Planet') IS NOT NULL
  DROP TABLE Planet

CREATE TABLE Planet (
        PlanetID        INT PRIMARY KEY,
        Name            VARCHAR(100) NOT NULL,
        MassEarths      DECIMAL(10,4),
        RadiusKm        DECIMAL(10,2),
        DistanceAU      DECIMAL(10,4),
        HasRings        BIT,
        Atmosphere      VARCHAR(255),
        DiscoveredBy    VARCHAR(100),
        DiscoveryYear   INT
    );
GO

-- Insert sample data only if table is empty
INSERT INTO Planet (PlanetID, Name, MassEarths, RadiusKm, DistanceAU, HasRings, Atmosphere, DiscoveredBy, DiscoveryYear)
    VALUES
    (1, 'Mercury', 0.055, 2439.7, 0.39, 0, 'Oxygen, Sodium, Hydrogen', NULL, NULL),
    (2, 'Venus',   0.815, 6051.8, 0.72, 0, 'CO2, Nitrogen', NULL, NULL),
    (3, 'Earth',   1.000, 6371.0, 1.00, 0, 'Nitrogen, Oxygen', NULL, NULL),
    (4, 'Mars',    0.107, 3389.5, 1.52, 0, 'CO2, Nitrogen, Argon', NULL, NULL),
    (5, 'Jupiter', 317.8, 69911,  5.20, 1, 'Hydrogen, Helium', 'Galileo Galilei', 1610),
    (6, 'Saturn',  95.16, 58232,  9.58, 1, 'Hydrogen, Helium', 'Galileo Galilei', 1610),
    (7, 'Uranus',  14.54, 25362, 19.22, 1, 'Hydrogen, Helium, Methane', 'William Herschel', 1781),
    (8, 'Neptune', 17.15, 24622, 30.05, 1, 'Hydrogen, Helium, Methane', 'Urbain Le Verrier', 1846);
GO
