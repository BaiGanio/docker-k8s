using System.Text.Json;

string json = File.ReadAllText("planets.json");
List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(json);

Entry(planets);

static void Entry(List<Planet>? planets)
{	
    Console.WriteLine("Choose your battle Unkindled:");
    Console.WriteLine("0. Print planets");

    Console.Write("\nEnter choice: ");
    var choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "0":
            Print(planets); // <= Your fight Unkindled
            break;
        default:
            Console.WriteLine("Battle unavailable.");
            break;
    }
}

static void Print(List<Planet> planets)
{
    Console.WriteLine("ID   Name       Mass(E)   Distance(AU)");
    Console.WriteLine("---------------------------------------");

    foreach (var p in planets)
        Console.WriteLine($"{p.PlanetID}    {p.Name,-10} {p.MassEarths,-8} {p.DistanceAU}");
}
