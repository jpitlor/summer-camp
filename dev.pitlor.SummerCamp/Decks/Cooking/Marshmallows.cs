using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record Marshmallows() : Card("Marshmallows", "Gain 2 snack bar tokens from the supply", "", 3, 2)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.getSnackBars(2);
    }
}