import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html } from "lit";

@customElement("page-wait-for-game")
export class PageWaitForGame extends StyledElement {
  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1>Wait for Game</h1>
      </div>
    `;
  }
}
