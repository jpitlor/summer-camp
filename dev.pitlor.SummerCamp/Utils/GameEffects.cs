using dev.pitlor.SummerCamp.Models;
using dev.pitlor.SummerCamp.Services;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Utils;

public class GameEffects(GamesService gamesService, string gameCode, string playerId) : IGameEffects
{
    public MoveResult MoveOnTrack(ChoiceOrValue<Path> track, int steps)
    {
        throw new NotImplementedException();
    }

    public void DrawCards(DeckLocation source, int count)
    {
        throw new NotImplementedException();
    }

    public ChoiceOrValue<int> DiscardCards(ChoiceOrValue<int> count)
    {
        throw new NotImplementedException();
    }

    public void GetSnackBars(int count)
    {
        throw new NotImplementedException();
    }

    public ChoiceOrValue<int> DiscardSnackBars(ChoiceOrValue<int> count)
    {
        throw new NotImplementedException();
    }

    public void GetEnergy(int count)
    {
        throw new NotImplementedException();
    }

    public void OtherGetsCard(ChoiceOrValue<string> player, DeckLocation destination, Card card)
    {
        throw new NotImplementedException();
    }

    public void OthersDrawCards(int count)
    {
        throw new NotImplementedException();
    }

    public void OthersDiscardCards(int count)
    {
        throw new NotImplementedException();
    }

    public void OthersGetSnackBars(int count)
    {
        throw new NotImplementedException();
    }

    public void OthersDiscardSnackBars(int count)
    {
        throw new NotImplementedException();
    }

    public void GetCards(DeckLocation source, DeckLocation destination, int maxCost)
    {
        throw new NotImplementedException();
    }

    public void SnackbarMultiplier(int multiplier)
    {
        throw new NotImplementedException();
    }
}