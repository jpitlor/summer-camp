using dev.pitlor.SummerCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dev.pitlor.SummerCamp.Modules;

[ApiController]
[Route("[controller]")]
public class GamesModule : ControllerBase
{
    private readonly Dictionary<string, Game> _games = new();
    
    [HttpGet]
    public Dictionary<string, Game> GetGames() => _games;
    
    [HttpPost]
    [Route("{id}")]
    public void CreateGame([FromBody] Game game, [FromRoute] string id)
    {
        if (!_games.TryAdd(id, game))
        {
            throw new ArgumentException("Game with id already exists", nameof(id));
        }
    }
}