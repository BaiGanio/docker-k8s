using System.Text.Json;

string json = File.ReadAllText("planets.json");
List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(json);

Console.WriteLine(new string('-', 90));
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

Console.WriteLine(new string('-', 90));

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
Console.WriteLine(new string('-', 90));