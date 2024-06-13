using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private const string GetGAmeEndPoint = "GetGame";
    private static readonly List<GameDto> games = [
        new (1,"Street Fighter","Action",3500.00M,new DateOnly(2001,2,2)),
        new (2,"Hello Fighter","Action",1500.30M,new DateOnly(2011,2,2)),
        new (3,"Byee Fighter","Action",3500.22M,new DateOnly(2010,2,2)),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGAmeEndPoint);

        group.MapPost("/", (CreatGameDto newGame) =>
        {
            GameDto gameDto = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(gameDto);

            return Results.CreatedAtRoute(GetGAmeEndPoint, new { id = gameDto.Id }, gameDto);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updateGameDto) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
                return Results.NotFound();

            games[index] = new GameDto(
                id,
                updateGameDto.Name,
                updateGameDto.Genre,
                updateGameDto.Price,
                updateGameDto.ReleaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
        return group;
    }
}