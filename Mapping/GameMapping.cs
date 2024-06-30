using GameStore.Entities;
using GameStore.Dtos;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreatGameDto gameDto)
    {
        Game game = new()
        {
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate
        };
        return game;
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(
          game.Id,
          game.Name,
          game.Genre!.Name,
          game.Price,
          game.ReleaseDate
      );
    }
    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }

    public static Game ToEntity(this UpdateGameDto gameDto, int id)
    {
        Game game = new()
        {
            Id = id,
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate
        };
        return game;
    }
}