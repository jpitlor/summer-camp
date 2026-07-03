import { customElement, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { nothing } from "lit";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import type { CreateGamePayload } from "../components/component-home-create-game.ts";
import type { Game } from "../models/game.ts";

@customElement("signalr-games-client")
export class SignalrGamesClient extends StyledElement {
  @state()
  connection?: HubConnection;

  connectedCallback() {
    super.connectedCallback();
    this.connection = new HubConnectionBuilder().withUrl("/games").build();
    this.connection.on("GameUpdated", this.onGameUpdated);
  }

  createGame(payload: CreateGamePayload) {
    this.connection?.invoke("CreateGame", payload);
  }

  joinGame() {}

  updatePlayer() {}

  startGame() {}

  onGameUpdated(game: Game) {
    this.dispatchEvent(new CustomEvent("gameUpdated", { detail: game }));
  }

  render() {
    return nothing;
  }
}

declare global {
  interface HTMLElementEventMap {
    gameUpdated: CustomEvent<Game>;
  }
}
