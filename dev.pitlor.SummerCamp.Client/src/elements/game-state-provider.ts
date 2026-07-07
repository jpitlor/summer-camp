import { customElement, state } from "lit/decorators.js";
import { createContext, provide } from "@lit/context";
import type { Game } from "../models/game.ts";
import { html } from "lit";
import { StyledElement } from "../StyledElement.ts";

export const gameContext = createContext<Game | undefined>("game");

@customElement("game-state-provider")
export class GameStateProvider extends StyledElement {
  @provide({ context: gameContext })
  @state()
  game: Game | undefined = undefined;

  connectedCallback() {
    super.connectedCallback();
    this.addEventListener("gameUpdated", this.setGame);
  }

  disconnectedCallback() {
    super.disconnectedCallback();
    this.removeEventListener("gameUpdated", this.setGame);
  }

  setGame(event: CustomEvent<Game>) {
    this.game = event.detail;
  }

  render() {
    return html`<slot></slot>`;
  }
}
