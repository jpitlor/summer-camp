using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record ZipLining(): Card("Zip lining", "Choose any card in the display that costs 4 energy or less and add it to your hand without spending any energy. You may now play it as usual", "", 6, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getCards(DeckLocation.Store, DeckLocation.Hand, 4);
    }
}