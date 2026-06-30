using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record ParachuteGames() : Card("Parachute Games", "Move 2 spaces on the games path", "", 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Value(Path.Deck(DeckName.Games)), 2);
    }
}