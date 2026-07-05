import { StyledElement } from "../StyledElement.ts";
import { customElement, query, queryAll, property } from "lit/decorators.js";
import { html } from "lit";
import { map } from "lit/directives/map.js";
import type { Color } from "../models/color.ts";

const colors = [
  { name: "red", className: "bg-red-500", borderClassName: "border-red-900" },
  {
    name: "blue",
    className: "bg-blue-500",
    borderClassName: "border-blue-900",
  },
  {
    name: "yellow",
    className: "bg-yellow-500",
    borderClassName: "border-yellow-900",
  },
  {
    name: "purple",
    className: "bg-purple-500",
    borderClassName: "border-purple-900",
  },
];

@customElement("component-home-wait-to-start")
export class ComponentHomeWaitToStart extends StyledElement {
  @property() gameId!: string;

  @query("[name=name]") nameInput!: HTMLInputElement;

  @queryAll("[name=color") colorInputs!: NodeListOf<HTMLInputElement>;

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
    )!.name;
    const payload = {
      name: this.nameInput.value,
      color: selectedColor,
      playerId: localStorage.getItem("playerId"),
      gameId: this.gameId,
    } as UpdatePlayerPayload;
    this.dispatchEvent(new CustomEvent("updatePlayer", { detail: payload }));
  };

  render() {
    return html`
      <div class="h-full w-full overflow-y-auto">
        <h1 class="text-center text-2xl font-bold">
          Waiting For Game To Start
        </h1>
        <p>Game ID: ${localStorage.getItem("gameId")}</p>
        <form class="flex flex-col gap-4 mt-8">
          <form-block>
            <label class="text-xs" for="name">Name</label>
            <input
              id="name"
              type="text"
              name="name"
              class="border-2 border-gray-300 rounded"
              @blur=${this.updatePlayer}
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
                      class="peer hidden"
                      @click=${this.updatePlayer}
                    />
                    <label .htmlFor=${`color-${color.name}`} .className=${`peer-checked:border-4 ${color.borderClassName} inline-block w-12 h-12 rounded ${color.className}`}
                    </label>
                  </div>
                `,
              )}
            </div>
          </form-block>
          <button
            type="submit"
            @click=${this.startGame}
            class="bg-yellow-100 border-amber-500 border-2 text-amber-500 p-2 rounded cursor-pointer hover:bg-amber-500 active:bg-amber-500 hover:text-yellow-100 active:text-yellow-100"
          >
            Start Game
          </button>
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
