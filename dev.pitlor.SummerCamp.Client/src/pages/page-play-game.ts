import { customElement, state } from "lit/decorators.js";
import { html, type PropertyValues } from "lit";
import Phaser, { AUTO, Scale } from "phaser";
import { StyledElement } from "../StyledElement.ts";
import { PlayGame } from "../components/scene-play-game.ts";
import { consume } from "@lit/context";
import { gameContext } from "../elements/game-state-provider.ts";
import type { Game } from "../models/game.ts";

@customElement("page-play-game")
export class PagePlayGame extends StyledElement {
  @state()
  game?: Phaser.Game;

  @consume({ context: gameContext, subscribe: true })
  gameContext!: Game | undefined;

  connectedCallback() {
    super.connectedCallback();
    this.game = new Phaser.Game({
      parent: "game-container",
      type: AUTO,
      backgroundColor: "#bae6fd",
      scale: {
        mode: Scale.RESIZE,
        autoCenter: Scale.CENTER_BOTH,
      },
      scene: [],
    });
  }

  protected update(changedProperties: PropertyValues) {
    super.update(changedProperties);
    if (!changedProperties.has("gameContext")) {
      return;
    }

    if (!changedProperties.get("gameContext") && !!this.gameContext) {
      this.game?.scene.add("Game", new PlayGame(this.gameContext), true);
    }
  }

  render() {
    return html` <div id="game-container"></div> `;
  }
}
