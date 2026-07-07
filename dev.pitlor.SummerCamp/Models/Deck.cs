namespace dev.pitlor.SummerCamp.Models;

public record Deck(Path Name, Card Move1Card, List<Badge> Badges, List<Card> StoreCards)
{
    protected Deck(DeckName name, Card move1Card, List<Badge> badges, List<Card> storeCards) : this(Path.Deck(name), move1Card, badges, storeCards)
    {
    }
};