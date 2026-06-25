namespace dev.pitlor.SummerCamp.Models;

public record BoardTile(int id, List<Tuple<int, Effect>> effects);