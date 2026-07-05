import { html } from "lit";
import { customElement, query } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import type { SignalrGamesClient } from "../elements/singalr-games-client.ts";
import type { CreateGamePayload } from "../components/component-home-create-game.ts";
import type { AppRouter } from "../elements/app-router.ts";

@customElement("page-home")
export class PageHome extends StyledElement {
  @query("signalr-games-client") signalrGamesClient!: SignalrGamesClient;

  @query("app-router") appRouter!: AppRouter;

  handleCreateGame = (e: CustomEvent<CreateGamePayload>) => {
    this.signalrGamesClient.createGame(e.detail);
    this.appRouter.navigate("/wait");
  };

  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <div
          class="bg-[url(/cards-background.webp)] bg-cover bg-top h-full flex items-center justify-center"
        >
          <div
            class="py-12 px-12 rounded-xl shadow backdrop-blur-sm bg-[#FFFFFFAA]"
          >
            <app-router>
              <app-route route="/">
                <component-home-menu></component-home-menu>
              </app-route>
              <app-route route="/create">
                <component-home-create-game
                  @createGame=${this.handleCreateGame}
                ></component-home-create-game>
              </app-route>
              <app-route route="/join">
                <component-home-join-game></component-home-join-game>
              </app-route>
              <app-route route="/wait">
                <component-home-wait-to-start></component-home-wait-to-start>
              </app-route>
            </app-router>
            <signalr-games-client></signalr-games-client>
          </div>
        </div>
      </div>
    `;
  }
}
