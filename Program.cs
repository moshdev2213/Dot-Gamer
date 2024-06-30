using GameStore.Endpoints;
using GameStore.Data;

var builder = WebApplication.CreateBuilder(args);

// register the service
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameDbContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "server online!");
app.MapGamesEndpoints();
app.MapGenresEndpoints();
await app.MigrateDbAsync();

app.Run();

