import type { Card } from "./card.ts";
import type { Path } from "./path.ts";
import type { Badge } from "./badge.ts";

export interface Deck {
  name: Path;
  move1Card: Card;
  badges: Badge[];
  storeCards: Card[];
}
