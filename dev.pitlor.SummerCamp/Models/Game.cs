namespace dev.pitlor.SummerCamp.Models;

public record struct Game(
    Deck Deck1,
    Deck Deck2,
    Deck Deck3,
    int SmoresLeft,
    int ScavengerHuntLeft,
    int FreeTimeLeft,
    List<Color> ColorOrder,
    Dictionary<string, Player> Players,
    List<BoardTile> BoardTiles,
    List<Badge> ParticipationBadges,
    List<Badge> AllStarBadges,
    string AdminPlayerId,
    bool IsStarted);