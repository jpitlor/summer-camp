using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record TieDye() : Card("Tie dye",
    "Discard any 1 card from your hand and then move 1 space on any path. You may do this twice", "", 6, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var discardCards = gameEffects.DiscardCards(ChoiceOrValue<int>.Choice([0, 1, 2]));
        for (var i = 0; i < discardCards.InternalValue; i++)
        {
            gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Choice(), 1);
        }
    }
}