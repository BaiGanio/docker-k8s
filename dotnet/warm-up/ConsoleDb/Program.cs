using Microsoft.Data.SqlClient;

while (true)
{
    Console.Write("Print planets? (y/n/exit): ");
    var input = Console.ReadLine()?.Trim().ToLower();

    if (input == "y")
    {
        var planets = GetPlanets();
        if(planets.Count == 0) continue;
        Print(planets);
        Console.WriteLine();
    }
    else if (input == "n")
    {
        Console.WriteLine("Okay, not printing.\n");
    }
    else if (input == "exit" || input == "q")
    {
        Console.WriteLine("Goodbye, Unkindled.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice.\n");
    }
}

static List<(int PlanetID, string Name, decimal MassEarths, decimal DistanceAU)> GetPlanets()
{
    List<(int PlanetID, string Name, decimal MassEarths, decimal DistanceAU)> planets = [];
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

static void Print(List<(int PlanetID, string Name, decimal MassEarths, decimal DistanceAU)> planets)
{
    Console.WriteLine("ID   Name       Mass(E)   Distance(AU)");
    Console.WriteLine("---------------------------------------");

    foreach (var p in planets)
        Console.WriteLine($"{p.PlanetID}    {p.Name,-10} {p.MassEarths,-8} {p.DistanceAU}");
}