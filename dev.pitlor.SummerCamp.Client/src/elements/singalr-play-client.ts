import { customElement, state } from "lit/decorators.js";
import { StyledElement } from "../StyledElement.ts";
import { nothing } from "lit";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

@customElement("signalr-play-client")
export class SignalrPlayClient extends StyledElement {
  @state()
  connection?: HubConnection;

  async connectedCallback() {
    super.connectedCallback();
    this.connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5226/play")
      .build();
    await this.connection.start();
  }

  render() {
    return nothing;
  }
}
