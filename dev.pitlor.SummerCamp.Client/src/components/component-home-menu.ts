import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html } from "lit";

@customElement("component-home-menu")
export class ComponentHomeMenu extends StyledElement {
  render() {
    return html`
      <div class="flex gap-8 items-center justify-center">
        <app-link href="/create">
          <div
            class="bg-white shadow-lg rounded py-2 px-4 text-xl inline-block cursor-pointer"
          >
            Start Game
          </div>
        </app-link>
        <app-link href="/join">
          <div class="bg-white shadow-lg rounded py-2 px-4 text-xl">
            Join Game
          </div>
        </app-link>
      </div>
    `;
  }
}
