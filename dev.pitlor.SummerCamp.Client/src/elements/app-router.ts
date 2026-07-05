import { customElement, state } from "lit/decorators.js";
import { createContext, provide } from "@lit/context";
import { StyledElement } from "../StyledElement.ts";
import { html } from "lit";

export const routeContext = createContext<string>("route");

@customElement("app-router")
export class AppRouter extends StyledElement {
  constructor() {
    super();
    this.addEventListener("navigate", this.onNavigate.bind(this));
  }

  @provide({ context: routeContext })
  @state()
  route = "/";

  onNavigate(event: CustomEvent<string>) {
    event.stopPropagation();
    this.route = event.detail;
  }

  navigate(route: string) {
    this.route = route;
  }

  render() {
    return html`<slot></slot>`;
  }
}
