using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record Flashlight() : Card("Flashlight", "Draw 2 cards", "", 5, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.drawCards(DeckLocation.DrawPile, 2);
    }
}