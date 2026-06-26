namespace dev.pitlor.SummerCamp.Models;

public record Path(bool isCustom, DeckName? deckName, string? customName)
{
    public static Path Custom(string customName) => new(true, null, customName);
    public static Path Deck(DeckName deckName) => new(false, deckName, null);
    
    public string Name => (isCustom ? customName : deckName.ToString())!;
}