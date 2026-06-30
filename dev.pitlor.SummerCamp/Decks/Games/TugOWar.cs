using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record TugOWar() : Card("Tug-O-War", "Gain 2 snack bars. All other players must discard 1 snack bar.", "", 3, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetSnackBars(2);
        gameEffects.OthersDiscardSnackBars(1);
    }
}