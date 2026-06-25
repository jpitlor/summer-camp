using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record ClimbingWall() : Card("Climbing wall", "Choose any card in the display that costs 6 energy or less. Place it face-up on your discard pile without spending any energy", "", 6, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getCards(DeckLocation.Store, DeckLocation.DiscardPile, 6);
    }
}