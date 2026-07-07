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
import { sleep } from "../util/sleep.ts";

@customElement("signalr-games-client")
export class SignalrGamesClient extends StyledElement {
  @state()
  connection?: HubConnection;

  async connectedCallback() {
    super.connectedCallback();
    this.connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5226/games")
      .build();
    this.connection.on("GameUpdated", this.onGameUpdated.bind(this));
    await this.connection.start();
  }

  async tryReconnect(playerId: string): Promise<string | undefined> {
    while (!this.connection || this.connection.state !== "Connected") {
      await sleep(200);
    }

    return this.connection.invoke<string>("TryReconnect", playerId);
  }

  async createGame(payload: CreateGamePayload) {
    while (!this.connection || this.connection.state !== "Connected") {
      await sleep(200);
    }

    await this.connection.invoke(
      "CreateGame",
      payload.gameId,
      payload.paths[0],
      payload.paths[1],
      payload.paths[2],
      payload.playerId,
    );
  }

  async joinGame(payload: JoinGamePayload) {
    while (!this.connection || this.connection.state !== "Connected") {
      await sleep(200);
    }

    await this.connection.invoke("JoinGame", payload.gameId, payload.playerId);
  }

  async updatePlayer(payload: UpdatePlayerPayload) {
    while (!this.connection || this.connection.state !== "Connected") {
      await sleep(200);
    }

    await this.connection.invoke(
      "UpdatePlayer",
      payload.gameId,
      payload.playerId,
      payload.name,
      payload.color,
    );
  }

  async startGame(payload: StartGamePayload) {
    while (!this.connection || this.connection.state !== "Connected") {
      await sleep(200);
    }

    await this.connection.invoke("StartGame", payload.gameId, payload.playerId);
  }

  onGameUpdated(game: Game) {
    const customEvent = new CustomEvent("gameUpdated", {
      detail: game,
      bubbles: true,
      composed: true,
    });
    this.dispatchEvent(customEvent);
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
