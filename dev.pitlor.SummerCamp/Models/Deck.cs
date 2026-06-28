namespace dev.pitlor.SummerCamp.Models;

public record Deck(Path name, Card move1Card, List<Card> storeCards)
{
    protected Deck(DeckName name, Card move1Card, List<Card> storeCards) : this(Path.Deck(name), move1Card, storeCards)
    {
    }
};