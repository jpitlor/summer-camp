import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html } from "lit";

@customElement("component-home-menu")
export class ComponentHomeMenu extends StyledElement {
  createGame = () => {
    this.dispatchEvent(new CustomEvent("create-game"));
  };

  render() {
    return html`
      <div class="flex gap-8 items-center justify-center">
        <a
          @click=${this.createGame}
          class="bg-white shadow-lg rounded py-2 px-4 text-xl inline-block cursor-pointer"
        >
          Start Game
        </a>
        <app-link href="/list">
          <div class="bg-white shadow-lg rounded py-2 px-4 text-xl">
            Join Game
          </div>
        </app-link>
      </div>
    `;
  }
}
