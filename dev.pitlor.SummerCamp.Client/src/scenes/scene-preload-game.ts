import Phaser from "phaser";
import uniqBy from "lodash.uniqby";
import type { Game } from "../models/game.ts";

export class PreloadGame extends Phaser.Scene {
  gameModel: Game;

  constructor(gameModel: Game) {
    super("PreloadGame");
    this.gameModel = gameModel;
  }

  preload() {
    this.registry.set("isGamePreloaded", true);
    const decks = [
      this.gameModel.deck1,
      this.gameModel.deck2,
      this.gameModel.deck3,
    ];
    for (const deck of decks) {
      const deckName = deck.name.isCustom
        ? deck.name.customName
        : deck.name.deckName;

      if (deck.name.isCustom) {
        this.load.image(
          `${deckName}-${deck.move1Card.name}`,
          deck.move1Card.base64Image,
        );
        for (const card of uniqBy(deck.storeCards, "name")) {
          this.load.image(`${deckName}-${card.name}`, card.base64Image);
        }
        for (const badge of deck.badges) {
          this.load.image(
            `${deckName}-badge-${badge.points}`,
            badge.base64Image,
          );
        }
      } else {
        const move1Slug = deck.move1Card.name
          .replaceAll(/[^A-Za-z0-9 ]/g, "")
          .replaceAll(" ", "-")
          .toLowerCase();
        this.load.image(
          `${deckName}-${deck.move1Card.name}`,
          `decks/${deckName}/${move1Slug}.jpg`,
        );
        for (const card of uniqBy(deck.storeCards, "name")) {
          const cardSlug = card.name
            .replaceAll(/[^A-Za-z0-9 ]/g, "")
            .replaceAll(" ", "-")
            .toLowerCase();
          this.load.image(
            `${deckName}-${card.name}`,
            `decks/${deckName}/${cardSlug}.jpg`,
          );
        }
        for (const i of [12, 10, 8, 6]) {
          this.load.image(
            `${deckName}-badge-${i}`,
            `decks/${deckName}/badge-${i}.png`,
          );
        }
      }
    }
  }

  create() {
    this.scene.start("PlayGame");
  }
}
