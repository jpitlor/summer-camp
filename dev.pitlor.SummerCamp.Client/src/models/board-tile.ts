import type { Effect } from "./effect.ts";

export interface BoardTile {
  id: number;
  effects: [number, Effect][];
}
