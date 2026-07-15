import { customElement, state } from "lit/decorators.js";
import { createContext, provide } from "@lit/context";
import type { Game } from "../models/game.ts";
import { html } from "lit";
import { StyledElement } from "../StyledElement.ts";

export const gameContext = createContext<Game | undefined>("game");
export const gameCodeContext = createContext<string | undefined>("gameCode");

@customElement("game-state-provider")
export class GameStateProvider extends StyledElement {
  @provide({ context: gameContext })
  @state()
  game: Game | undefined = undefined;

  @provide({ context: gameCodeContext })
  @state()
  gameCode: string | undefined = undefined;

  connectedCallback() {
    super.connectedCallback();
    this.addEventListener("gameUpdated", this.setGame);
    this.addEventListener("gameCodeUpdated", this.setGameCode);
  }

  disconnectedCallback() {
    super.disconnectedCallback();
    this.removeEventListener("gameUpdated", this.setGame);
    this.removeEventListener("gameCodeUpdated", this.setGameCode);
  }

  setGame(event: CustomEvent<Game>) {
    this.game = event.detail;
  }

  setGameCode(event: CustomEvent<string>) {
    this.gameCode = event.detail;
  }

  render() {
    return html`<slot></slot>`;
  }
}
