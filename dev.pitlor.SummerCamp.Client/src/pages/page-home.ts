import { html } from "lit";
import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";

@customElement("page-home")
export class PageHome extends StyledElement {
  createGame = () => {

  };

  render() {
    return html`
      <div
        class="bg-[url(/logo.jpg)] bg-cover bg-top h-full flex items-center justify-center"
      >
        <div
          class="py-12 px-12 rounded-xl shadow backdrop-blur-md bg-[#FFFFFF88]"
        >
          <app-router>
            <app-route route="/">
              <component-home-menu @create-game=${this.createGame}></component-home-menu>
            </app-route>
            <app-route route="/list">
              <component-home-game-list></component-home-game-list>
            </app-route>
          </app-router>
        </div>
      </div>
    `;
  }
}
