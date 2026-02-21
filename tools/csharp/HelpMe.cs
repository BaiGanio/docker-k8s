
using Microsoft.Data.SqlClient;
using System.Text.Json;

public static class HelpMe
{
    const string connectionString = "Server=localhost,1433;Database=Planets;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;";
    const int width = 90;
    static readonly List<Planet> planets = [];
    
    public static List<Planet> ReadPlanets()
    {
        string json = File.ReadAllText("planets.json");
        List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(json);
        return planets;
    }

    static List<Planet> GetPlanets()   
    {
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
                    MassEarths: reader.IsDBNull(2) ? null : reader.GetDecimal(2),
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
    
    public static void Print(List<Planet> planets)
    {
        if (planets.Count == 0) return;
        
        Console.WriteLine(new string('-', width));
        Console.WriteLine(Center("📡  PLANETARY SCAN RESULTS  📡"));
        Console.WriteLine(new string('-', width));

        if (planets.Count == 0) return;

        // Column headers
        Console.WriteLine(
            $"{ "ID",-4}  " +
            $"{ "Name",-10}  " +
            $"{ "Mass(E)",-8}  " +
            $"{ "Radius(km)",-12}  " +
            $"{ "Dist(AU)",-8}  " +
            $"{ "Rings",-6}  " +
            $"{ "Atmosphere",-30}"
            // $"{ "Discovered By",-20}  " +
            // $"{ "Year",-6}"
        );

        Console.WriteLine(new string('-', width));

        foreach (var p in planets)
        {
            Console.WriteLine(
                $"{p.PlanetID,-4}  " +
                $"{p.Name,-10}  " +
                $"{p.MassEarths,-8:0.###}  " +
                $"{p.RadiusKm,-12:0.##}  " +
                $"{p.DistanceAU,-8:0.##}  " +
                $"{(p.HasRings.Value ? "Yes" : "No"),-6}  " +
                $"{p.Atmosphere,-30}"
                // $"{(p.DiscoveredBy ?? "Unknown"),-20}  " +
                // $"{(p.DiscoveryYear?.ToString() ?? "----"),-6}"
            );
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', width));
        Console.WriteLine(Center("Scan complete. No anomalies detected."));
        Console.WriteLine(new string('-', width));
    }

    public static void PrintHeader()
    {
        Console.WriteLine(new string('=', width));
        Console.WriteLine(Center("⚔️  UNKINDLED COMMAND HUB  ⚔️"));
        Console.WriteLine(new string('=', width));
    }
    
    public static void PrintChoice(int counter)
    {
        Console.WriteLine();
        Console.WriteLine(Center($"--- ROUND {counter} ---"));
        Console.WriteLine(Center("Choose your battle, Unkindled"));
        Console.WriteLine();

        Console.WriteLine(Center("[0]  Print planets (partial info)"));
        Console.WriteLine(Center("[exit]  Retreat to the bonfire"));
        Console.WriteLine();

        Console.Write(Center("Your choice: "));
    }
    
    public static void PrintFooter()
    {
        Console.WriteLine(new string('=', width));
        Console.WriteLine(Center("🔥 FAREWELL, UNKINDLED 🔥"));
        Console.WriteLine(new string('=', width));
    }
    
    public static string Center(string text)
    {
        if (text.Length >= width) return text;
        int left = (width - text.Length) / 2;
        return new string(' ', left) + text;
    }
}