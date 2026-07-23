using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record PocketKnife() : Card("Pocket knife", "Draw 3 cards", Path.Outdoors, 8, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 3);
    }
};