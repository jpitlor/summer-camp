using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record Tag() : Card("Tag",
    "Move 1 space in any path. If you land on a space with the player to your right, draw 1 card.", Path.Games, 5, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        var result = gameEffects.MoveOnTrack(ChoiceOrValue<Path>.Choice(), 1);
        var mySpotInOrder = game.ColorOrder.IndexOf((Color)player.Color!);
        var playerToRight = game.ColorOrder[(mySpotInOrder + 1) % game.ColorOrder.Count];
        if (result.Players.Any(p => p.Color == playerToRight))
        {
            gameEffects.DrawCards(DeckLocation.DrawPile, 1);
        }
    }
}