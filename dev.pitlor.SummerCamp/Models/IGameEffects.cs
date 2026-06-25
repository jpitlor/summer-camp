namespace dev.pitlor.SummerCamp.Models;

// TODO: How can I incorporate when user choice is needed in this interface?
public interface IGameEffects
{
    void moveOnTrack(int track, int steps);
    void drawCards(DeckLocation source, int count);
    void discardCards(int count);
    void getSnackBars(int count);
    void getEnergy(int count);
    void othersGetCards(List<string> players, DeckLocation destination, Card card);
    void othersDrawCards(List<string> players);
    void othersDiscardCards(List<string> players);
    void othersGetSnackBars(List<string> players);
    void getCards(DeckLocation source, DeckLocation destination, int maxCost);
    void snackbarMultiplier(int multiplier);
}