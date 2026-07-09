import { StyledElement } from "../StyledElement.ts";
import { customElement, query, queryAll, state } from "lit/decorators.js";
import { html, type PropertyValues } from "lit";
import { map } from "lit/directives/map.js";
import type { Color } from "../models/color.ts";
import { consume } from "@lit/context";
import { gameContext } from "../elements/game-state-provider.ts";
import type { Game } from "../models/game.ts";
import { when } from "lit/directives/when.js";

const colors = [
  { name: "Red", className: "bg-red-500", borderClassName: "border-red-900" },
  {
    name: "Blue",
    className: "bg-blue-500",
    borderClassName: "border-blue-900",
  },
  {
    name: "Yellow",
    className: "bg-yellow-500",
    borderClassName: "border-yellow-900",
  },
  {
    name: "Purple",
    className: "bg-purple-500",
    borderClassName: "border-purple-900",
  },
];

@customElement("component-home-wait-to-start")
export class ComponentHomeWaitToStart extends StyledElement {
  @state() gameId!: string;

  @query("[name=name]") nameInput!: HTMLInputElement;

  @queryAll("[name=color") colorInputs!: NodeListOf<HTMLInputElement>;

  @consume({ context: gameContext, subscribe: true })
  game!: Game | undefined;

  protected firstUpdated(_changedProperties: PropertyValues) {
    super.firstUpdated(_changedProperties);
    this.gameId = localStorage.getItem("gameId")!;
  }

  startGame = (e: Event) => {
    e.preventDefault();
    const payload = {
      gameId: this.gameId,
      playerId: localStorage.getItem("playerId"),
    } as StartGamePayload;
    this.dispatchEvent(new CustomEvent("startGame", { detail: payload }));
    return false;
  };

  updatePlayer = () => {
    const selectedColor = Array.from(this.colorInputs.values()).find(
      (i) => i.checked,
    )?.value;
    const payload = {
      name: this.nameInput.value,
      color: selectedColor,
      playerId: localStorage.getItem("playerId"),
      gameId: this.gameId,
    } as UpdatePlayerPayload;
    this.dispatchEvent(new CustomEvent("updatePlayer", { detail: payload }));
  };

  render() {
    const playerId = localStorage.getItem("playerId");
    const otherPlayers = Object.entries(this.game?.players || {})
      .filter(([x]) => x !== playerId)
      .map(([, p]) => p);
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1 class="text-center text-2xl font-bold">
          Waiting For Game To Start
        </h1>
        <p>Game ID: ${localStorage.getItem("gameId")}</p>
        <form class="flex flex-col gap-4 mt-8" @submit=${this.startGame}>
          <form-block>
            <label class="text-xs" for="name">Name</label>
            <input
              id="name"
              type="text"
              name="name"
              class="border-2 border-gray-300 rounded"
              @blur=${this.updatePlayer}
              placeholder=${this.game?.players[
                localStorage.getItem("playerId")!
              ].name}
            />
          </form-block>
          <form-block>
            <label class="text-xs" for="color">Color</label>
            <div class="flex flex-row gap-4 justify-center">
              ${map(
                colors,
                (color) => html`
                  <div>
                    <input
                      type="radio"
                      name="color"
                      .id=${`color-${color.name}`}
                      .value=${color.name}
                      .disabled=${otherPlayers.some((p) => p.color === color.name)}
                      class="peer hidden"
                      @click=${this.updatePlayer}
                    />
                    <label .htmlFor=${`color-${color.name}`} .className=${`peer-checked:border-4 ${color.borderClassName} inline-block w-12 h-12 rounded ${otherPlayers.some((p) => p.color === color.name) ? "bg-gray-300" : color.className}`}
                    </label>
                  </div>
                `,
              )}
            </div>
          </form-block>
          <form-block>
            <label class="text-xs">Other Players</label>
            <div class="flex flex-row gap-4 justify-center">
              ${map(
                otherPlayers,
                (player) => html`
                  <div class="flex flex-col gap-1">
                    <div class="text-sm text-center">${player.name}</div>
                    <div
                      .className=${`inline-block w-12 h-12 rounded ${colors.find((x) => x.name === player.color)?.className || "bg-gray-300"}`}
                    />
                  </div>
                `,
              )}
            </div>
          </form-block>
          ${when(
            this.game?.adminPlayerId === playerId,
            () => html`
              <button
                type="submit"
                class="bg-yellow-100 border-amber-500 border-2 text-amber-500 p-2 rounded cursor-pointer hover:bg-amber-500 active:bg-amber-500 hover:text-yellow-100 active:text-yellow-100"
              >
                Start Game
              </button>
            `,
            () =>
              html`<form-block>
                <label class="text-sm">Waiting for admin to start game</label>
              </form-block>`,
          )}
        </form>
      </div>
    `;
  }
}

export interface UpdatePlayerPayload {
  gameId: string;
  playerId: string;
  name: string;
  color: Color;
}

export interface StartGamePayload {
  gameId: string;
  playerId: string;
}

declare global {
  interface HTMLElementEventMap {
    updatePlayer: CustomEvent<UpdatePlayerPayload>;
    startGame: CustomEvent<StartGamePayload>;
  }
}
