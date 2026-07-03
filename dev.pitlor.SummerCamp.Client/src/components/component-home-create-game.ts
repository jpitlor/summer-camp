import { StyledElement } from "../StyledElement.ts";
import { customElement, state } from "lit/decorators.js";
import { html } from "lit";
import { map } from "lit/directives/map.js";
import { range } from "lit/directives/range.js";
import type { DeckSelectedPayload } from "../elements/deck-choice.ts";
import type { Path } from "../models/path.ts";

@customElement("component-home-create-game")
export class ComponentHomeCreateGame extends StyledElement {
  @state()
  selectedDecks = {} as Record<number, string>;

  updateSelectedDecks(e: CustomEvent<DeckSelectedPayload>) {
    this.selectedDecks = {
      ...this.selectedDecks,
      [e.detail.id]: e.detail.deck,
    };
  }

  getDisabledDecks = (i: number) => {
    return Object.values(this.selectedDecks).filter(
      (x) => !this.selectedDecks[i] || x !== this.selectedDecks[i],
    );
  };

  createGame = (e: Event) => {
    e.preventDefault();
    const payload = {
      decks: Object.keys(this.selectedDecks).map((d) => ({ name: d })),
    } as CreateGamePayload;
    this.dispatchEvent(new CustomEvent("createGame", { detail: payload }));
    return false;
  };

  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1 class="text-center text-2xl font-bold">Create Game</h1>
        <form class="flex flex-col gap-4 mt-8">
          ${map(
            range(3),
            (i) => html`
              <deck-choice
                .index=${i}
                .disabledDecks=${this.getDisabledDecks(i)}
                @deck-selected=${this.updateSelectedDecks}
              ></deck-choice>
            `,
          )}
          <button
            type="submit"
            @click=${this.createGame}
            class="bg-yellow-100 border-amber-500 border-2 text-amber-500 p-2 rounded cursor-pointer hover:bg-amber-500 active:bg-amber-500 hover:text-yellow-100 active:text-yellow-100"
          >
            Start Game
          </button>
        </form>
      </div>
    `;
  }
}

export interface CreateGamePayload {
  gameId: string;
  playerId: string;
  paths: Path[];
}

declare global {
  interface HTMLElementEventMap {
    createGame: CustomEvent<CreateGamePayload>;
  }
}
