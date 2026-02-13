using System.Text.Json;

var json = File.ReadAllText("planets.json");
var planets = JsonSerializer.Deserialize<List<Planet>>(json);

Console.WriteLine("Choose your battle Unkindled:");
Console.WriteLine("0. Demo");
Console.WriteLine("1. Total Solar System Diameter");
Console.WriteLine("2. Total Atmosphere Components");
Console.WriteLine("3. Average Planet Mass");
Console.WriteLine("4. Count Ringed Planets");

Console.Write("\nEnter choice: ");
var choice = Console.ReadLine();

Console.WriteLine();

switch (choice)
{
    case "0":
        Console.WriteLine("ID   Name       Mass(E)   Distance(AU)");
        Console.WriteLine("---------------------------------------");

        foreach (var p in planets)
			Console.WriteLine($"{p.PlanetID}    {p.Name,-10} {p.MassEarths,-8} {p.DistanceAU}");
        break;

    default:
        Console.WriteLine("Battle unavailable.");
        break;
}