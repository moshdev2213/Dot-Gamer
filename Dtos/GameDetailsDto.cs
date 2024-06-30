using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class GameDetailsDto(
    int Id,
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
);
