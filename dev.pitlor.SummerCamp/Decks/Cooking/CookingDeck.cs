using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Decks.Cooking;

public record CookingDeck() : Deck(
    Path.Cooking, 
    new KitchenChores(),
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory
        .OfCards(
            new Tuple<int, Card>(4, new BaconAndEggs()),
            new Tuple<int, Card>(3, new Stew()),
            new Tuple<int, Card>(3, new Marshmallows()),
            new Tuple<int, Card>(2, new HotCocoa()),
            new Tuple<int, Card>(7, new FireMaking()),
            new Tuple<int, Card>(5, new PizzaMaking()))
        .Shuffle()
        .ToList());