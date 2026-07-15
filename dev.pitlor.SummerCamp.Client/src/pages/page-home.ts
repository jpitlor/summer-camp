import { html, type PropertyValues } from "lit";
import { customElement, query } from "lit/decorators.js";
import { consume } from "@lit/context";
import { StyledElement } from "../StyledElement.ts";
import { type SignalrGamesClient } from "../elements/singalr-games-client.ts";
import type { CreateGamePayload } from "../components/component-home-create-game.ts";
import { type AppRouter } from "../elements/app-router.ts";
import {
  gameCodeContext,
  gameContext,
} from "../elements/game-state-provider.ts";
import type { Game } from "../models/game.ts";
import type {
  StartGamePayload,
  UpdatePlayerPayload,
} from "../components/component-home-wait-to-start.ts";
import type { JoinGamePayload } from "../components/component-home-join-game.ts";

@customElement("page-home")
export class PageHome extends StyledElement {
  @query("signalr-games-client") signalrGamesClient!: SignalrGamesClient;

  @query("app-router") appRouter!: AppRouter;

  @consume({ context: gameContext, subscribe: true })
  game!: Game | undefined;

  @consume({ context: gameCodeContext, subscribe: true })
  gameCode!: string | undefined;

  protected async firstUpdated(changedProperties: PropertyValues) {
    super.firstUpdated(changedProperties);

    const playerId = localStorage.getItem("playerId")!;
    const existingGameId = await this.signalrGamesClient.tryReconnect(playerId);
    if (existingGameId) {
      this.dispatchEvent(
        new CustomEvent("gameCodeUpdated", {
          bubbles: true,
          composed: true,
          detail: existingGameId,
        }),
      );
    }
  }

  protected async updated(changedProperties: PropertyValues) {
    super.updated(changedProperties);
    if (!this.game || !this.gameCode) {
      return;
    }

    if (this.game.isStarted) {
      this.dispatchEvent(new CustomEvent("redirectToGame"));
      return;
    }

    this.appRouter.navigate("/wait");
  }

  handleCreateGame = async (e: CustomEvent<CreateGamePayload>) => {
    await this.signalrGamesClient.createGame(e.detail);
    this.appRouter.navigate("/wait");
  };

  handleUpdatePlayer = async (e: CustomEvent<UpdatePlayerPayload>) => {
    await this.signalrGamesClient.updatePlayer(e.detail);
  };

  handleJoinGame = async (e: CustomEvent<JoinGamePayload>) => {
    await this.signalrGamesClient.joinGame(e.detail);
  };

  handleStartGame = async (e: CustomEvent<StartGamePayload>) => {
    await this.signalrGamesClient.startGame(e.detail);
  };

  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <div
          class="bg-[url(/cards-background.webp)] bg-cover bg-top h-full flex items-center justify-center"
        >
          <div
            class="py-12 px-12 rounded-xl shadow backdrop-blur-sm bg-[#FFFFFFAA]"
          >
            <app-router>
              <app-route route="/">
                <component-home-menu></component-home-menu>
              </app-route>
              <app-route route="/create">
                <component-home-create-game
                  @createGame=${this.handleCreateGame}
                ></component-home-create-game>
              </app-route>
              <app-route route="/join">
                <component-home-join-game
                  @joinGame=${this.handleJoinGame}
                ></component-home-join-game>
              </app-route>
              <app-route route="/wait">
                <component-home-wait-to-start
                  @updatePlayer=${this.handleUpdatePlayer}
                  @startGame=${this.handleStartGame}
                ></component-home-wait-to-start>
              </app-route>
            </app-router>
            <signalr-games-client></signalr-games-client>
          </div>
        </div>
      </div>
    `;
  }
}

declare global {
  interface HTMLElementEventMap {
    redirectToGame: CustomEvent<void>;
  }
}
