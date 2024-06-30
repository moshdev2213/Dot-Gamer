namespace GameStore.Entities;
public class Game{
    public string Name { get; set; }
    public int Id { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}