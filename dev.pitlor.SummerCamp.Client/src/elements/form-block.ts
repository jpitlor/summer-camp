import { customElement } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { html } from "lit";

@customElement("form-block")
export class FormBlock extends StyledElement {
  render() {
    return html`
      <div
        class="flex flex-col bg-white rounded py-2 px-4 border-amber-500 border-2"
      >
        <slot></slot>
      </div>
    `;
  }
}
