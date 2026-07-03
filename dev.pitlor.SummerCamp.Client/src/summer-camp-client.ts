import { customElement } from "lit/decorators.js";
import { html } from "lit";
import { v4 as uuid } from "uuid";
import { StyledElement } from "./StyledElement.ts";

import "./components/component-home-menu.ts";
import "./components/component-home-create-game.ts";
import "./components/component-home-join-game.ts";
import "./components/component-home-wait-to-start.ts";
import "./elements/app-link.ts";
import "./elements/app-route.ts";
import "./elements/app-router.ts";
import "./elements/deck-choice.ts";
import "./elements/form-block.ts";
import "./elements/singalr-games-client.ts";
import "./elements/singalr-play-client.ts";
import "./pages/page-home.ts";
import "./pages/page-play-game.ts";

@customElement("summer-camp-client")
export class SummerCampClient extends StyledElement {
  connectedCallback() {
    super.connectedCallback();
    if (!localStorage.getItem("clientId")) {
      localStorage.setItem("clientId", uuid());
    }
  }

  render() {
    return html`
      <app-router>
        <app-route route="/">
          <page-home></page-home>
        </app-route>
        <app-route route="/play">
          <page-play-game></page-play-game>
        </app-route>
      </app-router>
    `;
  }
}
