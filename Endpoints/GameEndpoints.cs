using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{
    private const string GetGAmeEndPoint = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        //ensures all the endopint is parameter validated
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", async(GameDbContext gameDbContext) => 
            await gameDbContext.Games
            .Include(game=>game.Genre)
            .Select(game=>game.ToGameSummaryDto())
            .AsNoTracking()
            .ToListAsync()
        );

        group.MapGet("/{id}", async(int id,GameDbContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);
            
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto);
        }).WithName(GetGAmeEndPoint);

        group.MapPost("/", async(CreatGameDto newGame, GameDbContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGAmeEndPoint,
                 new { id = game.Id },
                 game.ToGameDetailsDto()
                 );
        });

        group.MapPut("/{id}", async(int id, UpdateGameDto updateGameDto,GameDbContext gameDbContext) =>
        {
            var exitingGame = await gameDbContext.Games.FindAsync(id);

            if (exitingGame is null)
                return Results.NotFound();

            gameDbContext.Entry(exitingGame)
            .CurrentValues
            .SetValues(updateGameDto.ToEntity(id));

            await gameDbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async(int id,GameDbContext gameDbContext) =>
        {
            await gameDbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });
        return group;
    }
}