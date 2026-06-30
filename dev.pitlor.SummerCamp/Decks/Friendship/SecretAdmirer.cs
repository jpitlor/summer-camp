using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record SecretAdmirer() : Card("Secret admirer",
    "Gain 5 energy. Then put this card face-up on any other player's discard pile.", "", 2, 0)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        gameEffects.GetEnergy(5);
        gameEffects.OtherGetsCard(ChoiceOrValue<string>.Choice(), DeckLocation.DiscardPile, new SecretAdmirer());
    }
}