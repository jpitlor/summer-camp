using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.WaterSports;

public record WaterSportsDeck() : Deck(
    DeckName.WaterSports,
    new WaterSafety(),
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory
        .OfCards(
            new Tuple<int, Card>(3, new WaterBlob()),
            new Tuple<int, Card>(3, new Fishing()),
            new Tuple<int, Card>(3, new SwimPractice()),
            new Tuple<int, Card>(3, new WaterSkiing()),
            new Tuple<int, Card>(7, new Canoeing()),
            new Tuple<int, Card>(5, new Sailing()))
        .Shuffle()
        .ToList());