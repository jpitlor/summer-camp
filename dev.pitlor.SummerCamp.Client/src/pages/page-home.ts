import { html } from "lit";
import { customElement } from "lit/decorators.js";
import { StyledElement } from "./StyledElement.ts";

@customElement("page-home")
export class PageHome extends StyledElement {
  render() {
    return html`
      <div class="bg-[url(/logo.jpg)] bg-cover bg-top h-full">
        <div
          class="absolute bottom-1/4 w-full flex items-center justify-center"
        >
          <div
            class="flex gap-8 items-center justify-center  py-12 px-12 rounded-xl shadow backdrop-blur-lg"
          >
            <app-link href="/create">
              <div class="bg-white shadow-lg rounded py-2 px-4 text-xl">
                Start Game
              </div>
            </app-link>
            <app-link href="/games">
              <div class="bg-white shadow-lg rounded py-2 px-4 text-xl">
                Join Game
              </div>
            </app-link>
          </div>
        </div>
      </div>
    `;
  }
}
