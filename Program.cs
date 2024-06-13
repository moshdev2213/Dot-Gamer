using GameStore.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "server online!");
app.MapGamesEndpoints();

app.Run();
