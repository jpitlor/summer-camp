import { StyledElement } from "../StyledElement.ts";
import { customElement, query } from "lit/decorators.js";
import { html } from "lit";

@customElement("component-home-join-game")
export class ComponentHomeJoinGame extends StyledElement {
  @query("[name=game-code]") gameCode!: HTMLInputElement;

  joinGame = (e: Event) => {
    e.preventDefault();
    const payload = {
      playerId: localStorage.getItem("playerId"),
      gameId: this.gameCode.value,
    } as JoinGamePayload;
    this.dispatchEvent(
      new CustomEvent("joinGame", {
        detail: payload,
        composed: true,
        bubbles: true,
      }),
    );
    this.dispatchEvent(
      new CustomEvent("gameCodeUpdated", {
        bubbles: true,
        composed: true,
        detail: this.gameCode.value,
      }),
    );
    return false;
  };

  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1 class="text-center text-2xl font-bold">Join Game</h1>
        <form class="flex flex-col gap-4 mt-8">
          <form-block>
            <label class="text-xs" for="game-code">Game Code</label>
            <input
              id="game-code"
              type="text"
              name="game-code"
              class="border-2 border-gray-300 rounded"
            />
          </form-block>
          <button
            type="submit"
            @click=${this.joinGame}
            class="bg-yellow-100 border-amber-500 border-2 text-amber-500 p-2 rounded cursor-pointer hover:bg-amber-500 active:bg-amber-500 hover:text-yellow-100 active:text-yellow-100"
          >
            Join Game
          </button>
        </form>
      </div>
    `;
  }
}

export interface JoinGamePayload {
  gameId: string;
  playerId: string;
}

declare global {
  interface HTMLElementEventMap {
    joinGame: CustomEvent<JoinGamePayload>;
  }
}
