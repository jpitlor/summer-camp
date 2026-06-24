import { html } from "lit";
import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";

@customElement("page-home")
export class PageHome extends StyledElement {
  render() {
    return html`
      <div
        class="bg-[url(/logo.jpg)] bg-cover bg-top h-full flex items-center justify-center"
      >
        <div
          class="py-12 px-12 rounded-xl shadow backdrop-blur-sm bg-[#FFFFFFAA]"
        >
          <app-router>
            <app-route route="/">
              <component-home-menu></component-home-menu>
            </app-route>
            <app-route route="/create">
              <component-home-create-game></component-home-create-game>
            </app-route>
            <app-route route="/join">
              <component-home-join-game></component-home-join-game>
            </app-route>
            <app-route route="/wait">
              <component-home-wait-to-start></component-home-wait-to-start>
            </app-route>
          </app-router>
        </div>
      </div>
    `;
  }
}
