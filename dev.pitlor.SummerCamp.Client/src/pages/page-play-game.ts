import { customElement } from "lit/decorators.js";
import { html } from "lit";
import { AUTO, Game, Scale } from "phaser";
import { StyledElement } from "../StyledElement.ts";
import { PlayGame } from "../components/scene-play-game.ts";

@customElement("page-play-game")
export class PagePlayGame extends StyledElement {
  connectedCallback() {
    super.connectedCallback();
    new Game({
      parent: "game-container",
      type: AUTO,
      backgroundColor: "#bae6fd",
      scale: {
        mode: Scale.RESIZE,
        autoCenter: Scale.CENTER_BOTH,
      },
      scene: [PlayGame],
    });
  }

  render() {
    return html` <div id="game-container"></div> `;
  }
}
