using Microsoft.EntityFrameworkCore;

public class PlanetsDbContext : DbContext
{
    public PlanetsDbContext(DbContextOptions<PlanetsDbContext> options)
        : base(options) { }

    public DbSet<Planet> Planets => Set<Planet>();
}
