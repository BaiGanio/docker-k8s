using System.Data.SqlClient;

string conn = "Server=sql-server;Database=Planets;User Id=sa;Password=P@ssw0rd;";

using var connection = new SqlConnection(conn);

await connection.OpenAsync();

Console.WriteLine("Connected to SQL Server!");

var cmd = new SqlCommand("SELECT COUNT(*) FROM Planet", connection);
var count = (int)await cmd.ExecuteScalarAsync();

Console.WriteLine($"Planets in DB: {count}");
