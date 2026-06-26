using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record CookingDeck() : Deck(DeckName.Cooking, 
    DeckFactory.OfCards(
        new Tuple<int, Card>(4, new BaconAndEggs()),
        new Tuple<int, Card>(3, new Stew()),
        new Tuple<int, Card>(3, new Marshmallows()),
        new Tuple<int, Card>(2, new HotCocoa()),
        new Tuple<int, Card>(4, new KitchenChores()),
        new Tuple<int, Card>(7, new FireMaking()),
        new Tuple<int, Card>(5, new PizzaMaking())));