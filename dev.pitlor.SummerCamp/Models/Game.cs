namespace dev.pitlor.SummerCamp.Models;

public record Game(
    Deck Deck1,
    Deck Deck2,
    Deck Deck3,
    int SmoresLeft,
    int ScavengerHuntLeft,
    int FreeTimeLeft,
    List<Color> ColorOrder,
    List<Player> Players,
    List<BoardTile> BoardTiles);