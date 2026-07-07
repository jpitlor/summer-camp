import { customElement, property } from "lit/decorators.js";
import { html } from "lit";
import { StyledElement } from "../StyledElement.ts";

@customElement("app-link")
export class Link extends StyledElement {
  @property({ type: String })
  href = "";

  visit = () => {
    this.dispatchEvent(
      new CustomEvent("navigate", {
        detail: this.href,
        bubbles: true,
        composed: true,
      }),
    );
  };

  render() {
    return html`<a href="#" @click=${this.visit}><slot></slot></a>`;
  }
}

declare global {
  interface HTMLElementEventMap {
    navigate: CustomEvent<string>;
  }
}
