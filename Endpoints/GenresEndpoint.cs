using GameStore.Data;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GenresEndpoint
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");
        group.MapGet("/", async (GameDbContext gameDbContext) =>
        {
            return await gameDbContext.Genres
            .Select(genre => genre.ToDto())
            .AsNoTracking()
            .ToListAsync();
        });
        
        return group;
    }
}