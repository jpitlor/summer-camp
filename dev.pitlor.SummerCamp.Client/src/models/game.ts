import type { Deck } from "./deck.ts";
import type { BoardTile } from "./board-tile.ts";
import type { Player } from "./player.ts";

export interface Game {
  deck1: Deck;
  deck2: Deck;
  deck3: Deck;
  smoresLeft: number;
  scavengerHuntLeft: number;
  freeTimeLeft: number;
  playerOrder: string[];
  players: Record<string, Player>;
  boardTiles: BoardTile[];
  adminPlayerId: string;
  isStarted: boolean;
}
