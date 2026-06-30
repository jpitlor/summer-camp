namespace dev.pitlor.SummerCamp.Models;

public record Path(bool IsCustom, DeckName? DeckName, string? CustomName)
{
    public static Path Custom(string customName) => new(true, null, customName);
    public static Path Deck(DeckName deckName) => new(false, deckName, null);
    
    public string Name => (IsCustom ? CustomName : DeckName.ToString())!;
}