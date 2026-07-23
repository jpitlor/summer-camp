namespace dev.pitlor.SummerCamp.Models;

public abstract record Card(string Name, string Description, Path DeckName, string Base64Image, int Cost, int Points)
{
    protected Card(string Name, string Description, Path DeckName, int Cost, int Points) : this(Name, Description, DeckName, "", Cost, Points)
    {
    }
    
    public abstract void Play(IGameEffects gameEffects, Game game, Player player);

    public void Discard(IGameEffects gameEffects)
    {
        gameEffects.GetEnergy(1);
    }
}
