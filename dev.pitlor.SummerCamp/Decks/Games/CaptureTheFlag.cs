using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record CaptureTheFlag() : Card("Capture the flag",
    "Move 1 space in any path. If you land on a space with the player to your right, gain 2 snackbars.", Path.Games, 5, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var result = gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Choice(), 1);
        var mySpotInOrder = game.PlayerOrder.FindIndex(p => game.Players[p] == player);
        var playerToRight = game.PlayerOrder[(mySpotInOrder + 1) % game.PlayerOrder.Count];
        if (result.Players.Any(p => p == game.Players[playerToRight]))
        {
            gameEffects.GetSnackBars(2);
        }
    }
}