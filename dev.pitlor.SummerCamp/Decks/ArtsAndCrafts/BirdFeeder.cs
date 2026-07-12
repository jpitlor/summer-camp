using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record BirdFeeder() : Card("Birdfeeder",
    "For this turn, any snack bar tokens you choose to spend are worth 2 energy instead of 1. Playing multiple bird feeder cards in a turn has no added effect",
    "", 3, 2)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.SnackbarMultiplier(2);
    }
}