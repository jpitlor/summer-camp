using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record FriendshipBracelet() : Card("Friendship bracelet",
    "Draw 3 cards. Then put this card face-up on any other player's discard pile.", Path.Friendship, 3, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.DrawCards(DeckLocation.DrawPile, 3);
        gameEffects.OtherGetsCard(ChoiceOrValue<string>.Choice(), DeckLocation.DiscardPile, new FriendshipBracelet());
    }
}