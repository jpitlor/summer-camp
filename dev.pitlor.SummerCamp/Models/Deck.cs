namespace dev.pitlor.SummerCamp.Models;

public record Deck(Path Name, Card Move1Card, List<Card> StoreCards)
{
    protected Deck(DeckName name, Card move1Card, List<Card> storeCards) : this(Path.Deck(name), move1Card, storeCards)
    {
    }
};