using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Outdoors;

public record OutdoorsDeck() : Deck(
    DeckName.Outdoors,
    new NatureWalk(), 
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory
        .OfCards(
            new Tuple<int, Card>(4, new Flashlight()),
            new Tuple<int, Card>(2, new PocketKnife()),
            new Tuple<int, Card>(3, new PlantIdentification()),
            new Tuple<int, Card>(3, new BirdWatching()),
            new Tuple<int, Card>(7, new Hiking()),
            new Tuple<int, Card>(5, new CampingTrip()))
        .Shuffle()
        .ToList());