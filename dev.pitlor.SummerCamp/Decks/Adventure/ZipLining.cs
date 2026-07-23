using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record ZipLining(): Card("Zip lining", "Choose any card in the display that costs 4 energy or less and add it to your hand without spending any energy. You may now play it as usual", Path.Adventure, 6, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetCards(DeckLocation.Store, DeckLocation.Hand, 4);
    }
}