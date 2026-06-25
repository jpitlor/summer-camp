namespace dev.pitlor.SummerCamp.Models;

public record Player(
    string connectionId,
    string name,
    Color? color,
    List<Card> drawPile,
    List<Card> hand,
    List<Card> discardPile,
    int snackbars,
    int path1Progress,
    int path2Progress,
    int path3Progress,
    List<Badge> badges);