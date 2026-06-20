import { customElement } from "lit/decorators.js";
import { html } from "lit";
import { StyledElement } from "./StyledElement.ts";

@customElement("page-play-game")
export class PagePlayGame extends StyledElement {
  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1>Play Game</h1>
      </div>
    `;
  }
}
