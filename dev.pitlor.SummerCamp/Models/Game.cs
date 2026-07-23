using System.Collections.Immutable;

namespace dev.pitlor.SummerCamp.Models;

public record struct Game(
    Deck Deck1,
    Deck Deck2,
    Deck Deck3,
    int SmoresLeft,
    int ScavengerHuntLeft,
    int FreeTimeLeft,
    ImmutableList<string> PlayerOrder,
    Dictionary<string, Player> Players,
    ImmutableList<BoardTile> BoardTiles,
    ImmutableList<Badge> ParticipationBadges,
    ImmutableList<Badge> AllStarBadges,
    string AdminPlayerId,
    bool IsStarted,
    string CurrentPlayerId);