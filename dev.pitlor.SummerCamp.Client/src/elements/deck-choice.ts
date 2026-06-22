import { customElement, property, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html, nothing } from "lit";
import { map } from "lit/directives/map.js";
import { when } from "lit/directives/when.js";

const decks = [
  "Water Sports",
  "Outdoors",
  "Cooking",
  "Adventure",
  "Arts & Crafts",
  "Friendship",
  "Games",
  "Custom",
];

@customElement("deck-choice")
export class DeckChoice extends StyledElement {
  @property()
  index!: number;

  @property()
  disabledDecks!: string[];

  @state()
  isCustomDeck = false;

  onDeckSelected = (e: Event) => {
    const selectedIndex = (e.target as HTMLSelectElement).selectedIndex;
    this.dispatchEvent(
      new CustomEvent("deck-selected", {
        detail: {
          deck: decks[selectedIndex - 1],
          id: this.index,
        } as DeckSelectedPayload,
      }),
    );

    if (decks[selectedIndex - 1] === "Custom") {
      this.isCustomDeck = true;
    }
  };

  validateCustomDeck = () => {};

  render() {
    return html`
      <div class="flex flex-col bg-white rounded p-2">
        <label for="deck-${this.index}" class="text-xs">
          Deck ${this.index + 1}
        </label>
        <select
          id="deck-${this.index}"
          @change=${this.onDeckSelected}
          class="border-2 border-gray-600 mt-1 px-2 rounded"
        >
          <option value="">Select a deck</option>
          ${map(
            decks,
            (deck) =>
              html`<option
                id=${deck}
                .disabled=${this.disabledDecks.includes(deck)}
              >
                ${deck}
              </option>`,
          )}
        </select>
        ${when(
          this.isCustomDeck,
          () => html`
            <input
              type="file"
              accept="application/zip"
              id="custom-deck-${this.index}"
              class="border-2 border-gray-600 mt-1 px-2 rounded"
              placeholder="Select custom deck"
              @change=${this.validateCustomDeck}
            />
          `,
          () => nothing,
        )}
      </div>
    `;
  }
}

export interface DeckSelectedPayload {
  id: number;
  deck: string;
}

declare global {
  interface HTMLElementEventMap {
    deckSelected: CustomEvent<DeckSelectedPayload>;
  }
}
