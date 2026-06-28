import { customElement, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { nothing } from "lit";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

@customElement("signalr-games-client")
export class SignalrGamesClient extends StyledElement {
  @state()
  connection?: HubConnection;

  connectedCallback() {
    super.connectedCallback();
    this.connection = new HubConnectionBuilder().withUrl("/games").build();
  }

  render() {
    return nothing;
  }
}
