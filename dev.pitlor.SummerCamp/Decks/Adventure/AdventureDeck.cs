using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record AdventureDeck() : Deck(
    DeckName.Adventure, 
    new TireSwing(),
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory
        .OfCards(
            new Tuple<int, Card>(3, new ZipLining()), 
            new Tuple<int, Card>(3, new RopesCourse()),
            new Tuple<int, Card>(3, new ClimbingWall()),
            new Tuple<int, Card>(3, new CaveExploration()),
            new Tuple<int, Card>(7, new Archery()),
            new Tuple<int, Card>(5, new MountainBiking()))
        .Shuffle()
        .ToList());