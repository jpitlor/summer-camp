namespace dev.pitlor.SummerCamp.Models;

public record Path(bool IsCustom, DeckName DeckName, string CustomName)
{
    public static Path Custom(string customName) => new(true, DeckName.Custom, customName);
    public static Path WaterSports => new(false, DeckName.WaterSports, "");
    public static Path Outdoors => new(false, DeckName.Outdoors, "");
    public static Path Cooking => new(false, DeckName.Cooking, "");
    public static Path Adventure => new(false, DeckName.Adventure, "");
    public static Path ArtsAndCrafts => new(false, DeckName.ArtsAndCrafts, "");
    public static Path Friendship => new(false, DeckName.Friendship, "");
    public static Path Games => new(false, DeckName.Games, "");
    
    public string Name => IsCustom ? CustomName : DeckName.ToString();
}