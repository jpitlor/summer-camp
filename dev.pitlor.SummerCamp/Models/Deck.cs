namespace dev.pitlor.SummerCamp.Models;

public record Deck(Path name, List<Card> cards)
{
    protected Deck(DeckName name, List<Card> cards) : this(Path.Deck(name), cards)
    {
    }
};