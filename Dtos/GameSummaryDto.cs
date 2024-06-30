using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class GameSummaryDto(
    int Id,
    [Required][StringLength(50)] string Name,
    string Genre,
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
);
