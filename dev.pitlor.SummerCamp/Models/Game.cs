namespace dev.pitlor.SummerCamp.Models;

public record Game(
    Deck deck1,
    Deck deck2,
    Deck deck3,
    int smoresLeft,
    int scavengerHuntLeft,
    int freeTimeLeft,
    List<Color> colorOrder,
    List<Player> players,
    List<BoardTile> boardTiles);