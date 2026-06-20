import { customElement, property } from "lit/decorators.js";
import { html, LitElement, nothing } from "lit";
import { consume } from "@lit/context";
import { routeContext } from "./app-router.ts";
import { StyledElement } from "../StyledElement.ts";

@customElement("app-route")
export class AppRoute extends StyledElement {
  @property({ type: String })
  route!: string;

  @property({ type: LitElement })
  element!: LitElement;

  @consume({ context: routeContext, subscribe: true })
  currentRoute!: string;

  render() {
    console.log(this.currentRoute, this.route);
    if (this.currentRoute !== this.route) {
      return nothing;
    }

    return html`<slot></slot>`;
  }
}
