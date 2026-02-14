
using Microsoft.Data.SqlClient;
using System.Text.Json;

public static class HelpMe
{
    static readonly List<Planet> planets = [];
    static List<Planet> GetPlanets()
    {

        string json = File.ReadAllText("planets.json");
        List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(json);

    }
    static List<Planet> GetPlanets()   
    {
        string connectionString = "Server=localhost,1433;Database=Planets;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;";

        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connected to SQL Server in Docker!");

            var query = "SELECT PlanetID, Name, MassEarths, DistanceAU FROM Planet ORDER BY PlanetID"; 
            using var cmd = new SqlCommand(query, connection); 
            using var reader = cmd.ExecuteReader(); 
            
            while(reader.Read()) 
            { 
                planets.Add((
                    PlanetID: reader.GetInt32(0),
                    Name: reader.GetString(1),
                    MassEarths: reader.GetDecimal(2),
                    DistanceAU: reader.GetDecimal(3)
                ));

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        return planets;
    }

    static void Print(List<Planet> planets)
    {
        if(planets.Count == 0) return;
        
        Console.WriteLine("ID   Name       Mass(E)   Distance(AU)");
        Console.WriteLine("---------------------------------------");

        foreach (var p in planets)
            Console.WriteLine($"{p.PlanetID}    {p.Name,-10} {p.MassEarths,-8} {p.DistanceAU}");

        Console.WriteLine();
    }
}