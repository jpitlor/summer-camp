using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Adventure;

public record AdventureDeck() : Deck(DeckName.Adventure,
    DeckFactory.OfCards(
        new Tuple<int, Card>(3, new ZipLining()), 
        new Tuple<int, Card>(3, new RopesCourse()),
        new Tuple<int, Card>(3, new ClimbingWall()),
        new Tuple<int, Card>(3, new CaveExploration()),
        new Tuple<int, Card>(4, new TireSwing()),
        new Tuple<int, Card>(7, new Archery()),
        new Tuple<int, Card>(5, new MountainBiking())));