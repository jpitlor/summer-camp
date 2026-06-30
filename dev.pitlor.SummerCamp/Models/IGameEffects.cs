namespace dev.pitlor.SummerCamp.Models;

public interface IGameEffects
{
    MoveResult moveOnTrack(ChoiceOrValue<Path> track, int steps);
    void DrawCards(DeckLocation source, int count);
    ChoiceOrValue<int> DiscardCards(ChoiceOrValue<int> count);
    void GetSnackBars(int count);
    ChoiceOrValue<int> DiscardSnackBars(ChoiceOrValue<int> count);
    void GetEnergy(int count);
    void OthersGetCards(ChoiceOrValue<List<string>> players, DeckLocation destination, Card card);
    void OthersGetCards(ChoiceOrValue<string> player, DeckLocation destination, Card card);
    void OthersDrawCards(int count);
    void OthersDiscardCards(int count);
    void OthersGetSnackBars(int count);
    void GetCards(DeckLocation source, DeckLocation destination, int maxCost);
    void SnackbarMultiplier(int multiplier);
}