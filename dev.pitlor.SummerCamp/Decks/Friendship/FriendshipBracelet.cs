using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record FriendshipBracelet() : Card("Friendship bracelet",
    "Draw 3 cards. Then put this card face-up on any other player's discard pile.", "", 3, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 3);
        gameEffects.OthersGetCards(ChoiceOrValue<string>.Choice(), DeckLocation.DiscardPile, new FriendshipBracelet());
    }
}