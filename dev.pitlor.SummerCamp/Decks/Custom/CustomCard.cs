using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Custom;

public record CustomCard(
    string Name,
    string ImagePath,
    string Description,
    int Cost,
    int Points,
    Func<string, string> ImageReader) : Card(Name, Description, ImageReader(ImagePath), Cost, Points)
{
    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        throw new NotImplementedException();
    }
}