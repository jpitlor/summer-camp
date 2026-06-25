using dev.pitlor.SummerCamp.Decks;
using dev.pitlor.SummerCamp.Models;
using Microsoft.AspNetCore.SignalR;

namespace dev.pitlor.SummerCamp.Hubs;

public class GamesHub : Hub
{
    private readonly Dictionary<string, Game> _games = new();
    
    public Dictionary<string, Game> GetGames() => _games;
    
    public void CreateGame(string id, DeckName deck1, DeckName deck2, DeckName deck3)
    {
        var game = new Game(
            DeckFactory.Create(deck1),
            DeckFactory.Create(deck2),
            DeckFactory.Create(deck3),
            14,
            14,
            8,
            [],
            [],
            []);
        if (!_games.TryAdd(id, game))
        {
            throw new ArgumentException("Game with id already exists", nameof(id));
        }
    }
    
    public void JoinGame(string id)
    {
        if (!_games.TryGetValue(id, out var game))
        {
            throw new ArgumentException("Game with id does not exist", nameof(id));
        }

        if (game.players.Count >= 4)
        {
            throw new ArgumentException("Game is full", nameof(id));
        }

        var player = new Player(
            Context.ConnectionId,
            "",
            null,
            [],
            [],
            [],
            1,
            0,
            0,
            0,
            []);
        game.players.Add(player);
    }

    public Result StartGame(string id)
    {
        // Assert user is admin of game
        // Assert all players have names and picked colors
        // Set progress to 2 if there are four players
        // Set color order
        // Set board tiles

        return Result.Success();
    }
}