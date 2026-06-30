using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record CandyStash() : Card("Candy stash", "Gain 3 snack bars. All other players gain 1.", "", 3, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetSnackBars(3);
        gameEffects.OthersGetSnackBars(1);
    }
}