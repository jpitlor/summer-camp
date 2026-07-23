using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record Singalong() : Card("Sing-along", "Draw 2 cards. All other players draw 1.", Path.Friendship, 3, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 2);
        gameEffects.OthersDrawCards(1);
    }
}