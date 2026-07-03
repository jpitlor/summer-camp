namespace dev.pitlor.SummerCamp.Models;

public record struct Player(
    string? ConnectionId,
    string Name,
    Color? Color,
    List<Card> DrawPile,
    List<Card> Hand,
    List<Card> DiscardPile,
    int Snackbars,
    int Path1Progress,
    int Path2Progress,
    int Path3Progress,
    List<Badge> Badges);