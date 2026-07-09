using dev.pitlor.SummerCamp.Decks;
using dev.pitlor.SummerCamp.Decks.Core;
using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Services;

public class GamesService
{
    private readonly Dictionary<string, Game> _games = new();
    private readonly Dictionary<string, Deck> _customDecks = new();
    private readonly List<Color> _colors = [Color.Blue, Color.Purple, Color.Red, Color.Yellow];

    private readonly List<BoardTile> _boardTiles =
    [
        new(1, [
            new Tuple<int, Effect>(0, Effect.GetSnackBar),
            new Tuple<int, Effect>(1, Effect.DrawCard),
            new Tuple<int, Effect>(3, Effect.DrawCard),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(2, [
            new Tuple<int, Effect>(0, Effect.DrawCard),
            new Tuple<int, Effect>(3, Effect.MoveOne),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(3, [
            new Tuple<int, Effect>(1, Effect.GetSnackBar),
            new Tuple<int, Effect>(3, Effect.MoveOne),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(4, [
            new Tuple<int, Effect>(1, Effect.GetSnackBar),
            new Tuple<int, Effect>(3, Effect.GetSnackBar),
            new Tuple<int, Effect>(4, Effect.GetSnackBar),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(5, [
            new Tuple<int, Effect>(2, Effect.MoveOne),
            new Tuple<int, Effect>(4, Effect.GetSnackBar),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(6, [
            new Tuple<int, Effect>(1, Effect.MoveOne),
            new Tuple<int, Effect>(3, Effect.DrawCard),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(7, [
            new Tuple<int, Effect>(0, Effect.DrawCard),
            new Tuple<int, Effect>(1, Effect.DrawCard),
            new Tuple<int, Effect>(4, Effect.DrawCard),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(8, [
            new Tuple<int, Effect>(1, Effect.MoveOne),
            new Tuple<int, Effect>(4, Effect.MoveOne),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ]),
        new(9, [
            new Tuple<int, Effect>(0, Effect.DrawCard),
            new Tuple<int, Effect>(2, Effect.GetSnackBar),
            new Tuple<int, Effect>(4, Effect.GetSnackBar),
            new Tuple<int, Effect>(5, Effect.Bridge)
        ])
    ];

    public event EventHandler<Game>? OnGameUpdated;

    public void CreateGame(string gameId, Path path1, Path path2, Path path3, string playerId,
        string connectionId)
    {
        var deck1 = path1.IsCustom ? _customDecks[path1.CustomName] : DeckFactory.Create(path1.DeckName);
        var deck2 = path2.IsCustom ? _customDecks[path2.CustomName] : DeckFactory.Create(path2.DeckName);
        var deck3 = path3.IsCustom ? _customDecks[path3.CustomName] : DeckFactory.Create(path3.DeckName);
        var game = new Game(
            deck1,
            deck2,
            deck3,
            14,
            14,
            8,
            [],
            new Dictionary<string, Player>
            {
                {
                    playerId, new Player(
                        connectionId,
                        "",
                        null,
                        [],
                        [],
                        [],
                        1,
                        0,
                        0,
                        0,
                        [])
                }
            },
            [],
            playerId,
            false);
        if (!_games.TryAdd(gameId, game))
        {
            throw new ArgumentException("Game with id already exists", nameof(gameId));
        }
    }

    public void CleanGames()
    {
        var orphanedGames = _games.Keys
            .Where(k => _games[k].Players.Values.All(p => p.ConnectionId == null))
            .ToList();
        foreach (var game in orphanedGames)
        {
            _games.Remove(game);
        }
    }

    public void AddCustomDeck(string id, Deck deck)
    {
        _customDecks.Add(id, deck);
    }

    public string? GetExistingGameIdAndUpdateConnectionId(string playerId, string connectionId)
    {
        var existingGameId = _games.Keys.FirstOrDefault(k => _games[k].Players.ContainsKey(playerId));
        if (existingGameId == null)
        {
            return null;
        }

        _games[existingGameId].Players[playerId] =
            _games[existingGameId].Players[playerId] with { ConnectionId = connectionId };

        OnGameUpdated?.Invoke(this, _games[existingGameId]);
        return existingGameId;
    }

    public void JoinGame(string gameId, string playerId, string connectionId)
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
            connectionId,
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
        game.Players.Add(playerId, player);

        OnGameUpdated?.Invoke(this, _games[gameId]);
    }

    public void UpdatePlayer(string gameId, string playerId, string name, Color? color)
    {
        if (!_games.TryGetValue(gameId, out var game))
        {
            throw new ArgumentException($"Game with id {gameId} does not exist", nameof(gameId));
        }

        if (!game.Players.TryGetValue(playerId, out var player))
        {
            throw new ArgumentException($"Player with id {playerId} does not exist", nameof(playerId));
        }

        game.Players[playerId] = player with { Name = name, Color = color };
        OnGameUpdated?.Invoke(this, game);
    }

    public Result StartGame(string gameId, string playerId)
    {
        if (!_games.TryGetValue(gameId, out var game))
        {
            return Result.Failure($"Game with id {gameId} does not exist");
        }

        // Assert user is admin of game
        if (game.AdminPlayerId != playerId)
        {
            return Result.Failure($"Player {playerId} is not admin of game");
        }

        // Assert all players have names and picked colors
        if (game.Players.Values.Any(p => string.IsNullOrWhiteSpace(p.Name) || p.Color == null))
        {
            return Result.Failure("Not all players have set a name or picked a color");
        }

        // Set progress to 2 if there are four players
        if (game.Players.Count == 4)
        {
            foreach (var id in game.Players.Keys)
            {
                game.Players[id] = game.Players[id] with
                {
                    Path1Progress = 2,
                    Path2Progress = 2,
                    Path3Progress = 2
                };
            }
        }

        // Set color order
        game.ColorOrder = _colors.Shuffle().ToList();

        // Set board tiles
        game.BoardTiles = _boardTiles.Shuffle().ToList();
        
        // Deal out cards
        foreach (var player in game.Players)
        {
            player.Value.DrawPile.AddRange(DeckFactory.OfCards(
                new Tuple<int, Card>(7, new LightsOut()),
                new Tuple<int, Card>(1, game.Deck1.Move1Card),
                new Tuple<int, Card>(1, game.Deck2.Move1Card), 
                new Tuple<int, Card>(1, game.Deck3.Move1Card)));
        }

        // Set IsStarted
        game.IsStarted = true;

        _games[gameId] = game;
        OnGameUpdated?.Invoke(this, _games[gameId]);
        return Result.Success();
    }
}