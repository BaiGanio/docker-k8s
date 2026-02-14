public class Planet
{
    public int PlanetID { get; set; }
    public string Name { get; set; } = "";
    public decimal MassEarths { get; set; }
    public double RadiusKm { get; set; }
    public double DistanceAU { get; set; }
    public bool HasRings { get; set; }
    public string? Atmosphere { get; set; }
    public string? DiscoveredBy { get; set; }
    public int? DiscoveryYear { get; set; }
}
