using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Security.Cryptography; 
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core with SQL Server
builder.Services.AddDbContext<PlanetsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PlanetsDb")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

// 1. Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PlanetsDbContext>();
    db.Database.Migrate();

    // 2. Seed JSON if database empty OR JSON changed
    await SeedPlanetsAsync(db);
}

// Minimal API endpoint
app.MapGet("/planets", async (PlanetsDbContext db) =>
    await db.Planets.ToListAsync());

app.Run();

static async Task SeedPlanetsAsync(PlanetsDbContext db)
{
    var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "planets.json");
    var json = await File.ReadAllTextAsync(jsonPath);

    // Compute hash of JSON
    using var sha = SHA256.Create();
    var hash = Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(json)));

    // Get last seed state
    var state = await db.SeedState.FirstOrDefaultAsync();

    bool shouldSeed = state == null || state.JsonHash != hash;

    if (!shouldSeed)
        return;

    // Parse JSON
    var planets = JsonSerializer.Deserialize<List<Planet>>(json)!;

    // Clear table and reseed
    db.Planets.RemoveRange(db.Planets);
    await db.SaveChangesAsync();

    await db.Planets.AddRangeAsync(planets);

    // Update seed state
    if (state == null)
        db.SeedState.Add(new SeedState { JsonHash = hash });
    else
        state.JsonHash = hash;

    await db.SaveChangesAsync();
}
