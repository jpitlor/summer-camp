using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record GodsEye() : Card("God's eye",
    "Discard 2 snack bar tokens and then move 1 space on any path. You may do this 3 times.", "", 4, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var discardSnackBars = gameEffects.DiscardSnackBars(ChoiceOrValue<int>.Choice());
        for (var i = 0; i < discardSnackBars.InternalValue; i++)
        {
            gameEffects.moveOnTrack(ChoiceOrValue<Path>.Choice(), 1);
        }
    }
}