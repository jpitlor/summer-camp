import { customElement, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { nothing } from "lit";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import type { CreateGamePayload } from "../components/component-home-create-game.ts";
import type { Game } from "../models/game.ts";
import type { JoinGamePayload } from "../components/component-home-join-game.ts";
import type {
  StartGamePayload,
  UpdatePlayerPayload,
} from "../components/component-home-wait-to-start.ts";

@customElement("signalr-games-client")
export class SignalrGamesClient extends StyledElement {
  @state()
  connection?: HubConnection;

  async connectedCallback() {
    super.connectedCallback();
    this.connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5226/games")
      .build();
    this.connection.on("GameUpdated", this.onGameUpdated);
    await this.connection.start();
  }

  createGame(payload: CreateGamePayload) {
    this.connection?.invoke(
      "CreateGame",
      payload.gameId,
      payload.paths[0],
      payload.paths[1],
      payload.paths[2],
      payload.playerId,
    );
  }

  joinGame(payload: JoinGamePayload) {
    this.connection?.invoke("JoinGame", payload.gameId, payload.playerId);
  }

  updatePlayer(payload: UpdatePlayerPayload) {
    this.connection?.invoke(
      "UpdatePlayer",
      payload.gameId,
      payload.playerId,
      payload.name,
      payload.color,
    );
  }

  startGame(payload: StartGamePayload) {
    this.connection?.invoke("StartGame", payload.gameId, payload.playerId);
  }

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
