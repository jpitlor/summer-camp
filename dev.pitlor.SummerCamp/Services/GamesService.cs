using dev.pitlor.SummerCamp.Decks;
using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Services;

public class GamesService
{
    private readonly Dictionary<string, Game> _games = new();
    private readonly Dictionary<string, Deck> _customDecks = new();
    
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

    public void AddCustomDeck(string id, Deck deck)
    {
        _customDecks.Add(id, deck);
    }
    
    public void JoinGame(string gameId, string playerId)
    {
        if (!_games.TryGetValue(gameId, out var game))
        {
            throw new ArgumentException("Game with id does not exist", nameof(gameId));
        }

        if (game.Players.Count >= 4)
        {
            throw new ArgumentException("Game is full", nameof(gameId));
        }

        var player = new Player(
            playerId,
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
        game.Players.Add(player);
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