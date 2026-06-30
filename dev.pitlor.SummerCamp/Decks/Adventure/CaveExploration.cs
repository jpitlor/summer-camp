using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record CaveExploration() : Card("Cave exploration",
    "Choose 1 of the 3 activity draw piles. Draw the top card form it. Place it face-up on tour discard pile without spending any energy",
    "", 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetCards(DeckLocation.StoreTopDeck, DeckLocation.DiscardPile, int.MaxValue);
    }
}