using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record Marshmallows() : Card("Marshmallows", "Gain 2 snack bar tokens from the supply", Path.Cooking, 3, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetSnackBars(2);
    }
}