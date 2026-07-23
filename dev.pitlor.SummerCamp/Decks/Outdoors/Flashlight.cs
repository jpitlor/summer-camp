using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record Flashlight() : Card("Flashlight", "Draw 2 cards", Path.Outdoors, 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 2);
    }
}