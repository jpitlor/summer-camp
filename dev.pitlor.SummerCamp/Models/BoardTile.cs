namespace dev.pitlor.SummerCamp.Models;

public record BoardTile(int Id, List<Tuple<int, Effect>> Effects);