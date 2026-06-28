using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;

public record ArtsAndCraftsDeck() : Deck(DeckName.ArtsAndCrafts, new Boondoggle(),
    DeckFactory.OfCards(
        new Tuple<int, Card>(3, new TieDye()),
        new Tuple<int, Card>(3, new GodsEye()),
        new Tuple<int, Card>(3, new MacaroniSculpture()),
        new Tuple<int, Card>(3, new BirdFeeder()),
        new Tuple<int, Card>(7, new Ceramics()),
        new Tuple<int, Card>(5, new Leatherwork())));