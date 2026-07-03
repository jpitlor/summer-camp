namespace dev.pitlor.SummerCamp.Models;

public record Path(bool IsCustom, DeckName DeckName, string CustomName)
{
    public static Path Custom(string customName) => new(true, DeckName.Custom, customName);
    public static Path Deck(DeckName deckName) => new(false, deckName, "");
    
    public string Name => IsCustom ? CustomName : DeckName.ToString();
}