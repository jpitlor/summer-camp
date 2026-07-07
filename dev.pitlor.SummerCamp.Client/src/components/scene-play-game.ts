import { Scene } from "phaser";
import uniqBy from "lodash.uniqby";
import type { Game } from "../models/game.ts";

const colors = ["red", "green", "purple", "yellow"];

export class PlayGame extends Scene {
  _game: Game;

  constructor(game: Game) {
    super();
    this._game = game;
  }

  preload() {
    this.load.setPath("/");

    this.load.image("card-back", "card-back.jpg");
    this.load.image("snack-bar", "snack-bar.png");
    this.load.image("starting-camper", "starting-camper.png");

    for (const color of colors) {
      this.load.image(`board-${color}`, `player-boards/${color}.jpg`);
      this.load.image(`meaple-${color}`, `meaple/${color}.png`);
    }

    this.load.image("board-top", `board/top.jpg`);
    for (let i = 0; i < 10; i++) {
      this.load.image(`board-${i}`, `board/${i}.jpg`);
    }

    for (const deck of [this._game.deck1, this._game.deck2, this._game.deck3]) {
      if (deck.name.isCustom) {
        this.load.image(
          `${deck.name.deckName}-${deck.move1Card.name}`,
          deck.move1Card.base64Image,
        );
        for (const card of uniqBy(deck.storeCards, "name")) {
          this.load.image(
            `${deck.name.deckName}-${card.name}`,
            card.base64Image,
          );
        }
        for (const badge of deck.badges) {
          this.load.image(
            `${deck.name.deckName}-badge-${badge.points}`,
            badge.base64Image,
          );
        }
      } else {
        this.load.image(
          `${deck.name.deckName}-${deck.move1Card.name}`,
          `decks/${deck.name.deckName}/${deck.move1Card.name}.jpg`,
        );
        for (const card of uniqBy(deck.storeCards, "name")) {
          this.load.image(
            `${deck.name.deckName}-${card.name}`,
            `decks/${deck.name.deckName}/${card.name}.jpg`,
          );
        }
        for (const i of [12, 10, 8, 6]) {
          this.load.image(
            `${deck.name.deckName}-badge-${i}`,
            `decks/${deck.name.deckName}/badge-${i}.png`,
          );
        }
      }
    }
  }

  create() {}
}
