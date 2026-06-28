using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record FriendshipDeck() : Deck(DeckName.Friendship, 
    DeckFactory.OfCards(
        new Tuple<int, Card>(3, new SecretAdmirer()),
        new Tuple<int, Card>(3, new FriendshipBracelet()),
        new Tuple<int, Card>(3, new CandyStash()),
        new Tuple<int, Card>(3, new Singalong()),
        new Tuple<int, Card>(4, new NewFriend()),
        new Tuple<int, Card>(7, new CabinLoyalty()),
        new Tuple<int, Card>(5, new PenPals())));