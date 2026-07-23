using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record MacaroniSculpture() : Card("Macaroni sculpture",
    "Discard any 1 card from your hand and then gain 3 snack bar tokens. You may do this action twice.", Path.ArtsAndCrafts, 3, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var discardCards = gameEffects.DiscardCards(ChoiceOrValue<int>.Choice([0, 1, 2]));
        gameEffects.GetSnackBars(discardCards.InternalValue * 3);
    }
}