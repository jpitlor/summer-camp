import type { Color } from "./color.ts";
import type { Badge } from "./badge.ts";
import type { Card } from "./card.ts";

export interface Player {
  connectionId?: string;
  name: string;
  color?: Color;
  drawPile: Card[];
  hand: Card[];
  discardPile: Card[];
  snackbars: number;
  path1Progress: number;
  path2Progress: number;
  path3Progress: number;
  badges: Badge[];
}
