using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Core;

public record ScavengerHunt() : Card("Scavenger Hunt", "Discard 1-3 cards, then draw that many cards", "", 3, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var discarded = gameEffects.DiscardCards(ChoiceOrValue<int>.Choice());
        gameEffects.DrawCards(DeckLocation.DrawPile, discarded.InternalValue);
    }
}