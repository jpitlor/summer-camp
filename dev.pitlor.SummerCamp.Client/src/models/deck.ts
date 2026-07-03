import type { Card } from "./card.ts";
import type { Path } from "./path.ts";

export interface Deck {
  name: Path;
  move1Card: Card;
  storeCards: Card[];
}
