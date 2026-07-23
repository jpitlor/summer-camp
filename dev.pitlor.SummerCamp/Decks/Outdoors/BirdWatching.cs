using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record BirdWatching() : Card("Bird watching", "Draw 3 cards then discard 3 cards", Path.Outdoors, 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 3);
        gameEffects.DiscardCards(ChoiceOrValue<int>.Value(3));
    }
}