using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks.Custom;

public record CustomCard(
    string Name,
    string Description,
    string Base64Image,
    int Cost,
    int Points,
    List<CustomCardAction> Actions) : Card(Name, Description, Base64Image, Cost, Points)
{
    public static CustomCard Create(CustomCardConfig config, Func<string, string> imageReader) => new(
        config.Name,
        config.Description, 
        imageReader(config.ImagePath),
        config.Cost, 
        config.Points,
        config.Actions);

    public override void Play(IGameEffects gameEffects, Game game, Player player)
    {
        try
        {
            var state = new Dictionary<string, string>();
            foreach (var action in Actions)
            {

            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Custom card {Name} ran into an error. Skipping card effects");
            Console.Error.WriteLine(e.Message);
        }
    }
}