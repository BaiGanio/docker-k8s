-- Create the database
CREATE DATABASE Planets;

-- Switch to the database (MySQL / SQL Server)
USE Planets;

-- PostgreSQL users: run \c Planets instead

-- Create the main table
CREATE TABLE Planet (
    PlanetID        INT PRIMARY KEY,
    Name            VARCHAR(100) NOT NULL,
    MassEarths      DECIMAL(10,4),       -- Mass relative to Earth
    RadiusKm        DECIMAL(10,2),       -- Radius in kilometers
    DistanceAU      DECIMAL(10,4),       -- Distance from the Sun in AU
    HasRings        BOOLEAN,
    Atmosphere      VARCHAR(255),        -- Comma-separated gases
    DiscoveredBy    VARCHAR(100),
    DiscoveryYear   INT
);

-- Optional: Insert sample data
INSERT INTO Planet (PlanetID, Name, MassEarths, RadiusKm, DistanceAU, HasRings, Atmosphere, DiscoveredBy, DiscoveryYear)
VALUES
(1, 'Mercury', 0.055, 2439.7, 0.39, FALSE, 'Oxygen, Sodium, Hydrogen', NULL, NULL),
(2, 'Venus',   0.815, 6051.8, 0.72, FALSE, 'CO2, Nitrogen', NULL, NULL),
(3, 'Earth',   1.000, 6371.0, 1.00, FALSE, 'Nitrogen, Oxygen', NULL, NULL),
(4, 'Mars',    0.107, 3389.5, 1.52, FALSE, 'CO2, Nitrogen, Argon', NULL, NULL),
(5, 'Jupiter', 317.8, 69911,  5.20, TRUE,  'Hydrogen, Helium', 'Galileo Galilei', 1610),
(6, 'Saturn',  95.16, 58232,  9.58, TRUE,  'Hydrogen, Helium', 'Galileo Galilei', 1610),
(7, 'Uranus',  14.54, 25362, 19.22, TRUE,  'Hydrogen, Helium, Methane', 'William Herschel', 1781),
(8, 'Neptune', 17.15, 24622, 30.05, TRUE,  'Hydrogen, Helium, Methane', 'Urbain Le Verrier', 1846);
