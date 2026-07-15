import { customElement, property, state } from "lit/decorators.js";
import { html, type PropertyValues } from "lit";
import Phaser, { AUTO, Scale } from "phaser";
import { StyledElement } from "../StyledElement.ts";
import { PlayGame } from "../scenes/scene-play-game.ts";
import { consume } from "@lit/context";
import { gameContext } from "../elements/game-state-provider.ts";
import type { Game } from "../models/game.ts";
import { PreloadCommon } from "../scenes/scene-preload-common.ts";

@customElement("page-play-game")
export class PagePlayGame extends StyledElement {
  @state()
  game?: Phaser.Game;

  @consume({ context: gameContext, subscribe: true })
  @property({ attribute: false })
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
        width: window.innerWidth,
        height: window.innerHeight,
      },
      scene: [PreloadCommon, PlayGame],
    });
  }

  protected updated(changedProperties: PropertyValues) {
    super.update(changedProperties);
    if (!changedProperties.has("gameContext")) {
      return;
    }

    if (this.gameContext) {
      const scene = this.game?.scene.getScene<PlayGame>("PlayGame");
      scene?.setGame(this.gameContext);
    }
  }

  render() {
    return html` <div id="game-container"></div> `;
  }
}
