using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record PlantIdentification() : Card("Plant identification", "Draw any 1 card from your discard pile", Path.Outdoors, 4, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DiscardPile, 1);
    }
}