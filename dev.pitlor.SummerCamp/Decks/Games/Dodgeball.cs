using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record Dodgeball() : Card("Dodgeball", "Draw 2 cards. All other players must discard 1 card", "", 7, 1)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 2);
        gameEffects.OthersDiscardCards(1);
    }
}