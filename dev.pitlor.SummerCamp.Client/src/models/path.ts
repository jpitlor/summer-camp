import type { DeckName } from "./deck-name.ts";

export interface Path {
  isCustom: boolean;
  deckName: DeckName;
  customName: string;
}
