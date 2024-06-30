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

        group.MapGet("/", (GameDbContext gameDbContext) => 
            gameDbContext.Games
            .Include(game=>game.Genre)
            .Select(game=>game.ToGameSummaryDto())
            .AsNoTracking()
        );

        group.MapGet("/{id}", (int id,GameDbContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);
            
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto);
        }).WithName(GetGAmeEndPoint);

        group.MapPost("/", (CreatGameDto newGame, GameDbContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
                GetGAmeEndPoint,
                 new { id = game.Id },
                 game.ToGameDetailsDto()
                 );
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updateGameDto,GameDbContext gameDbContext) =>
        {
            var exitingGame = gameDbContext.Games.Find(id);

            if (exitingGame is null)
                return Results.NotFound();

            gameDbContext.Entry(exitingGame)
            .CurrentValues
            .SetValues(updateGameDto.ToEntity(id));

            gameDbContext.SaveChanges();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id,GameDbContext gameDbContext) =>
        {
            gameDbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDelete();

            return Results.NoContent();
        });
        return group;
    }
}