using System.Collections.Immutable;
using dev.pitlor.SummerCamp.Decks.Core;
using dev.pitlor.SummerCamp.Models;
using Path = dev.pitlor.SummerCamp.Models.Path;

namespace dev.pitlor.SummerCamp.Services;

public class PlayService(GamesService gamesService)
{
    public Result PlayCard(string connectionId, Path path, string cardName)
    {
        var gameCode = gamesService.GetGameCode(connectionId);
        if (gameCode is null)
        {
            return Result.Failure("Game not found");
        }

        var game = gamesService.GetGame(gameCode);
        var player = game.Players.First(p => p.Value.ConnectionId == connectionId);
        if (player.Key != game.CurrentPlayerId)
        {
            return Result.Failure("It is not your turn");
        }

        gamesService.UpdatePlayer(gameCode, player.Key, (mutablePlayer, gameEffects) =>
        {
            var card = mutablePlayer.Hand.First(c => c.DeckName == path && c.Name == cardName);
            card.Play(gameEffects, game, player.Value);
            return mutablePlayer with
            {
                Hand = mutablePlayer.Hand.Remove(card),
                DiscardPile = mutablePlayer.DiscardPile.Add(card)
            };
        });
        return Result.Success();
    }

    public Result DiscardCard(string connectionId, Path path, string cardName)
    {
        var gameCode = gamesService.GetGameCode(connectionId);
        if (gameCode is null)
        {
            return Result.Failure("Game not found");
        }

        var game = gamesService.GetGame(gameCode);
        var player = game.Players.First(p => p.Value.ConnectionId == connectionId);
        if (player.Key != game.CurrentPlayerId)
        {
            return Result.Failure("It is not your turn");
        }

        gamesService.UpdatePlayer(gameCode, player.Key, (mutablePlayer, gameEffects) =>
        {
            var card = mutablePlayer.Hand.First(c => c.DeckName == path && c.Name == cardName);
            card.Discard(gameEffects);
            return mutablePlayer with
            {
                Hand = mutablePlayer.Hand.Remove(card),
                DiscardPile = mutablePlayer.DiscardPile.Add(card)
            };
        });
        return Result.Success();
    }

    public Result BuyCard(string connectionId, Path path, string cardName)
    {
        var gameCode = gamesService.GetGameCode(connectionId);
        if (gameCode is null)
        {
            return Result.Failure("Game not found");
        }

        var game = gamesService.GetGame(gameCode);
        var player = game.Players.First(p => p.Value.ConnectionId == connectionId);
        if (player.Key != game.CurrentPlayerId)
        {
            return Result.Failure("It is not your turn");
        }

        // Let's just assume this card is one of the top two
        gamesService.UpdateGame(gameCode, mutableGame =>
        {
            Card card;
            var smoresLeft = mutableGame.SmoresLeft;
            var scavengerHuntLeft = mutableGame.ScavengerHuntLeft;
            var freeTimeLeft = mutableGame.FreeTimeLeft;
            if (mutableGame.Deck1.Name == path)
            {
                card = mutableGame.Deck1.StoreCards[0].Name == cardName
                    ? mutableGame.Deck1.StoreCards[0]
                    : mutableGame.Deck1.StoreCards[1];
                mutableGame.Deck1.StoreCards.Remove(card);
            }
            else if (mutableGame.Deck2.Name == path)
            {
                card = mutableGame.Deck2.StoreCards[0].Name == cardName
                    ? mutableGame.Deck2.StoreCards[0]
                    : mutableGame.Deck2.StoreCards[1];
                mutableGame.Deck2.StoreCards.Remove(card);
            }
            else if (game.Deck3.Name == path)
            {
                card = mutableGame.Deck3.StoreCards[0].Name == cardName
                    ? mutableGame.Deck3.StoreCards[0]
                    : mutableGame.Deck3.StoreCards[1];
                mutableGame.Deck3.StoreCards.Remove(card);
            }
            else // Must be the core deck
            {
                switch (cardName)
                {
                    case "smores": 
                        card = new Smores();
                        smoresLeft--;
                        break;
                    case "Scavenger hunt":
                        card = new ScavengerHunt();
                        scavengerHuntLeft--;
                        break;
                    default: 
                        card = new FreeTime();
                        freeTimeLeft--;
                        break;
                }
            }

            var mutablePlayer = mutableGame.Players[player.Key];
            mutableGame.Players[player.Key] = mutablePlayer with
            {
                Energy = mutablePlayer.Energy - card.Cost,
                DiscardPile = mutablePlayer.DiscardPile.Concat([card]).ToImmutableList()
            };

            return mutableGame with
            {
                SmoresLeft = smoresLeft,
                ScavengerHuntLeft = scavengerHuntLeft,
                FreeTimeLeft = freeTimeLeft
            };
        });
        return Result.Success();
    }

    public Result EndTurn(string connectionId)
    {
        var gameCode = gamesService.GetGameCode(connectionId);
        if (gameCode is null)
        {
            return Result.Failure("Game not found");
        }

        var game = gamesService.GetGame(gameCode);
        var player = game.Players.First(p => p.Value.ConnectionId == connectionId);
        if (player.Key != game.CurrentPlayerId)
        {
            return Result.Failure("It is not your turn");
        }

        var i = game.PlayerOrder.IndexOf(game.CurrentPlayerId);
        gamesService.UpdateGame(connectionId, g => g with
        {
            CurrentPlayerId = game.PlayerOrder[(i + 1) % game.PlayerOrder.Count]
        });
        gamesService.UpdatePlayer(gameCode, player.Key, (p, _) => p with
        {
            Energy = 0,
            DiscardPile = p.DiscardPile.Concat(player.Value.Hand).ToImmutableList(),
            Hand = p.DrawPile.GetRange(0, 5),
            DrawPile = p.DrawPile.RemoveRange(0, 5)
        });
        return Result.Success();
    }
}