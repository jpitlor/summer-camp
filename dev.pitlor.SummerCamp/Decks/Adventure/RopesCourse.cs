using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record RopesCourse() : Card("Ropes course", "Choose amy card in the display that costs 5 energy or less. Place it face-down on your discard pile without spending any energy", "", 6, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getCards(DeckLocation.Store, DeckLocation.DrawPile, 5);
    }
}