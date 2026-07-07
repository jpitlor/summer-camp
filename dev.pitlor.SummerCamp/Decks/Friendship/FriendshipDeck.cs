using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Friendship;

public record FriendshipDeck() : Deck(
    DeckName.Friendship,
    new NewFriend(),
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory.OfCards(
        new Tuple<int, Card>(3, new SecretAdmirer()),
        new Tuple<int, Card>(3, new FriendshipBracelet()),
        new Tuple<int, Card>(3, new CandyStash()),
        new Tuple<int, Card>(3, new Singalong()),
        new Tuple<int, Card>(7, new CabinLoyalty()),
        new Tuple<int, Card>(5, new PenPals())));