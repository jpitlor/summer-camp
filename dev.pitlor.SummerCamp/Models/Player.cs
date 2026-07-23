using System.Collections.Immutable;

namespace dev.pitlor.SummerCamp.Models;

public record struct Player(
    string? ConnectionId,
    string Name,
    Color? Color,
    ImmutableList<Card> DrawPile,
    ImmutableList<Card> Hand,
    ImmutableList<Card> DiscardPile,
    int Snackbars,
    int Energy,
    int Path1Progress,
    int Path2Progress,
    int Path3Progress,
    ImmutableList<Badge> Badges);