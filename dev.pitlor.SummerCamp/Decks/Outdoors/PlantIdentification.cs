using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record PlantIdentification() : Card("Plant identification", "Draw any 1 card from your discard pile", "", 4, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DiscardPile, 1);
    }
}