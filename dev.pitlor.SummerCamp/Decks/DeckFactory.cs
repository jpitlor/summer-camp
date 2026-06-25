using dev.pitlor.SummerCamp.Decks.Adventure;
using dev.pitlor.SummerCamp.Decks.ArtsAndCrafts;
using dev.pitlor.SummerCamp.Decks.Cooking;
using dev.pitlor.SummerCamp.Decks.Custom;
using dev.pitlor.SummerCamp.Decks.Friendship;
using dev.pitlor.SummerCamp.Decks.Games;
using dev.pitlor.SummerCamp.Decks.Outdoors;
using dev.pitlor.SummerCamp.Decks.WaterSports;
using dev.pitlor.SummerCamp.Models;

namespace dev.pitlor.SummerCamp.Decks;

public static class DeckFactory
{
    public static Deck Create(DeckName deckName)
    {
        return deckName switch
        {
            DeckName.WaterSports => new WaterSportsDeck(),
            DeckName.Outdoors => new OutdoorsDeck(),
            DeckName.Cooking => new CookingDeck(),
            DeckName.Adventure => new AdventureDeck(),
            DeckName.ArtsAndCrafts => new ArtsAndCraftsDeck(),
            DeckName.Friendship => new FriendshipDeck(),
            DeckName.Games => new GamesDeck(),
            DeckName.Custom => new CustomDeck(),
            _ => throw new ArgumentOutOfRangeException(nameof(deckName), deckName, null)
        };
    }
}