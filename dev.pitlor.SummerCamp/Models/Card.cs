namespace dev.pitlor.SummerCamp.Models;

public abstract record Card(string name, string description, string base64Image, int cost, int points)
{
    public abstract void Play(IGameEffects gameEffects);

    public void Discard(IGameEffects gameEffects)
    {
        gameEffects.getEnergy(1);
    }
}
