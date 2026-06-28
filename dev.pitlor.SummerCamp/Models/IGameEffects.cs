namespace dev.pitlor.SummerCamp.Models;

public interface IGameEffects
{
    ChoiceOrValue<Path> moveOnTrack(ChoiceOrValue<Path> track, int steps);
    void drawCards(DeckLocation source, int count);
    ChoiceOrValue<int> discardCards(ChoiceOrValue<int> count);
    void getSnackBars(int count);
    ChoiceOrValue<int> discardSnackBars(ChoiceOrValue<int> count);
    void getEnergy(int count);
    void othersGetCards(ChoiceOrValue<List<string>> players, DeckLocation destination, Card card);
    void othersGetCards(ChoiceOrValue<string> player, DeckLocation destination, Card card);
    void othersDrawCards(int count);
    void othersDiscardCards(int count);
    void othersGetSnackBars(int count);
    void getCards(DeckLocation source, DeckLocation destination, int maxCost);
    void snackbarMultiplier(int multiplier);
}