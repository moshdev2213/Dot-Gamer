using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos.Genre;

public record class GenreDto(
    int Id,
    [Required][StringLength(50)]string Name
);
