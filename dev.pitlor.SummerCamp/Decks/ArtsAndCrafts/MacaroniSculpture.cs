using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record MacaroniSculpture() : Card("Macaroni sculpture",
    "Discard any 1 card from your hand and then gain 3 snack bar tokens. You may do this action twice.", "", 3, 2)
{
    public override void Play(IGameEffects gameEffects)
    {
        var discardCards = gameEffects.discardCards(ChoiceOrValue<int>.Choice());
        gameEffects.getSnackBars(discardCards.value * 3);
    }
}