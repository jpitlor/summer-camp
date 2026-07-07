namespace dev.pitlor.SummerCamp.Decks.Custom;

public record CustomDeckConfig(
    string Name,
    CustomCardConfig Move1Card,
    List<CustomBadgeConfig> Badges,
    List<CardAndNumber> StoreCards);