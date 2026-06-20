import { StyledElement } from "../StyledElement.ts";
import { customElement } from "lit/decorators.js";
import { html } from "lit";

@customElement("component-home-game-list")
export class ComponentHomeGameList extends StyledElement {
  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1>Game List</h1>
      </div>
    `;
  }
}
