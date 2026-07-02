namespace dev.pitlor.SummerCamp.Decks.Custom;

public record CustomCardConfig(
    string Name,
    string Description,
    string ImagePath,
    int Cost,
    int Points,
    List<CustomCardAction> Actions);