namespace dev.pitlor.SummerCamp.Models;

public interface IGameEffects
{
    ChoiceOrValue<Path> moveOnTrack(ChoiceOrValue<Path> track, int steps);
    void drawCards(DeckLocation source, int count);
    ChoiceOrValue<int> discardCards(ChoiceOrValue<int> count);
    void getSnackBars(int count);
    ChoiceOrValue<int> discardSnackBars(ChoiceOrValue<int> count);
    void getEnergy(int count);
    void othersGetCards(List<string> players, DeckLocation destination, Card card);
    void othersDrawCards(List<string> players);
    void othersDiscardCards(List<string> players);
    void othersGetSnackBars(List<string> players);
    void getCards(DeckLocation source, DeckLocation destination, int maxCost);
    void snackbarMultiplier(int multiplier);
}