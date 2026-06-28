using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record Singalong() : Card("Sing-along", "Draw 2 cards. All other players draw 1.", "", 3, 1)
{
    public override void Play(IGameEffects gameEffects)
    {
        gameEffects.drawCards(DeckLocation.DrawPile, 2);
        gameEffects.othersDrawCards(1);
    }
}