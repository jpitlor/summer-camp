using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record PocketKnife() : Card("Pocket knife", "Draw 3 cards", "", 8, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.drawCards(DeckLocation.DrawPile, 3);
    }
};