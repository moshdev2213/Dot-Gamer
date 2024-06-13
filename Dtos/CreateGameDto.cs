using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CreatGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate
);