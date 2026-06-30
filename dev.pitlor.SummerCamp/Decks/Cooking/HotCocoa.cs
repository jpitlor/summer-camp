using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record HotCocoa() : Card("Hot cocoa", "Gain 3 snack bars from the supply", "", 4, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetSnackBars(3);
    }
}