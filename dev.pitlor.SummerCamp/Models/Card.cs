namespace dev.pitlor.SummerCamp.Models;

public abstract record Card(string Name, string Description, string Base64Image, int Cost, int Points)
{
    public abstract void Play(IGameEffects gameEffects, Game game, Player player);

    public void Discard(IGameEffects gameEffects)
    {
        gameEffects.GetEnergy(1);
    }
}
