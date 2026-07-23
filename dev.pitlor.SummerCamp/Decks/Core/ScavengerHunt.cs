using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record ScavengerHunt() : Card("Scavenger Hunt", "Discard 1-3 cards, then draw that many cards", Path.Custom("core"), 3, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var discarded = gameEffects.DiscardCards(ChoiceOrValue<int>.Choice([1, 2, 3]));
        gameEffects.DrawCards(DeckLocation.DrawPile, discarded.InternalValue);
    }
}