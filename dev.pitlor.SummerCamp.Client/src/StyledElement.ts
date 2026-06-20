import { css, LitElement } from "lit";

import tailwindStyles from "./index.css?inline";

export class StyledElement extends LitElement {
  static styles = [
    // @ts-ignore
    css([tailwindStyles]),
  ];
}
