using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Games;

public record GamesDeck() : Deck(
    DeckName.Games,
    new Tetherball(),
    [new Badge("", 12), new Badge("", 10), new Badge("", 8), new Badge("", 6)],
    DeckFactory
        .OfCards(
            new Tuple<int, Card>(4, new Tag()),
            new Tuple<int, Card>(3, new CaptureTheFlag()),
            new Tuple<int, Card>(2, new Dodgeball()),
            new Tuple<int, Card>(3, new TugOWar()),
            new Tuple<int, Card>(7, new ParachuteGames()),
            new Tuple<int, Card>(5, new ColorWar()))
        .Shuffle()
        .ToList());