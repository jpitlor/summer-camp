import { StyledElement } from "../StyledElement.ts";
import { customElement } from "lit/decorators.js";
import { html } from "lit";

const decks = [
  "Water Sports",
  "Outdoors",
  "Cooking",
  "Adventure",
  "Arts & Crafts",
  "Friendship",
  "Games",
];

@customElement("component-home-create-game")
export class ComponentHomeCreateGame extends StyledElement {
  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1>Create Game</h1>
        <form></form>
      </div>
    `;
  }
}
