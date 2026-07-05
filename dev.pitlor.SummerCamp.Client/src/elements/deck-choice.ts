import { customElement, property, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html, nothing } from "lit";
import { map } from "lit/directives/map.js";
import { when } from "lit/directives/when.js";
import type { DeckName } from "../models/deck-name.ts";

const decks = [
  { value: "WaterSports", label: "Water Sports" },
  { value: "Outdoors", label: "Outdoors" },
  { value: "Cooking", label: "Cooking" },
  { value: "Adventure", label: "Adventure" },
  { value: "ArtsAndCrafts", label: "Arts & Crafts" },
  { value: "Friendship", label: "Friendship" },
  { value: "Games", label: "Games" },
  { value: "Custom", label: "Custom" },
] as { value: DeckName; label: string }[];

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
          deck: decks[selectedIndex - 1].value,
          id: this.index,
        } as DeckSelectedPayload,
      }),
    );

    this.isCustomDeck = decks[selectedIndex - 1].value === "Custom";
  };

  validateCustomDeck = () => {};

  render() {
    return html`
      <form-block>
        <label for="deck-${this.index}" class="text-xs">
          Deck ${this.index + 1}
        </label>
        <select
          id="deck-${this.index}"
          @change=${this.onDeckSelected}
          class="mt-1 rounded"
        >
          <option value="">Select a deck</option>
          ${map(
            decks,
            (deck) =>
              html`<option
                id=${deck.value}
                value=${deck.value}
                .disabled=${this.disabledDecks.includes(deck.value)}
              >
                ${deck.label}
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
              class="border-2 border-dashed border-gray-300 bg-gray-100 mt-2 p-2 rounded"
              placeholder="Select custom deck"
              @change=${this.validateCustomDeck}
            />
          `,
          () => nothing,
        )}
      </form-block>
    `;
  }
}

export interface DeckSelectedPayload {
  id: number;
  deck: DeckName;
}

declare global {
  interface HTMLElementEventMap {
    deckSelected: CustomEvent<DeckSelectedPayload>;
  }
}
