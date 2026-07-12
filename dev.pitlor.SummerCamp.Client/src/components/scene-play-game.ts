import Phaser, { Scene } from "phaser";
import uniqBy from "lodash.uniqby";
import type { Game } from "../models/game.ts";
import Image = Phaser.GameObjects.Image;

const colors = ["Red", "Green", "Purple", "Yellow"];

export class PlayGame extends Scene {
  _game?: Game;
  _playerId = localStorage.getItem("playerId")!;
  _meaples: Record<string, Image[]> = {};
  _badges: Record<string, Image[]> = {};
  _decks: Record<string, Image[]> = {};

  constructor() {
    super("PlayGame");
  }

  preload() {
    this.load.setPath("/");

    this.load.image("card-back", "card-back.jpg");
    this.load.image("snack-bar", "snack-bar.png");
    this.load.image("starting-camper", "starting-camper.png");

    for (const color of colors) {
      this.load.image(
        `board-${color}`,
        `player-boards/${color.toLowerCase()}.jpg`,
      );
      this.load.image(`meaple-${color}`, `meaple/${color.toLowerCase()}.png`);
    }

    this.load.image("board-top", `board/top.jpg`);
    for (let i = 1; i < 10; i++) {
      this.load.image(`board-${i}`, `board/${i}.jpg`);
    }

    for (const i of [4, 6, 8]) {
      this.load.image(`all-star-${i}`, `decks/core/all-star-${i}.png`);
    }

    for (const i of [2, 4, 6]) {
      this.load.image(
        `participation-${i}`,
        `decks/core/participation-${i}.png`,
      );
    }

    for (const card of [
      "Free time",
      "Lights out",
      "Scavenger hunt",
      "Smores",
    ]) {
      const cardSlug = card
        .replaceAll(/[^A-Za-z0-9 ]/g, "")
        .replaceAll(" ", "-")
        .toLowerCase();
      this.load.image(`core-${card}`, `decks/core/${cardSlug}.jpg`);
    }
  }

  async setGame(game: Game) {
    const isFirstSet = Object.values(this._meaples).length === 0;
    this._game = game;
    if (isFirstSet) {
      await this.createGame();
    } else {
      this.updateGame();
    }
  }

  async createGame() {
    if (!this._game) {
      console.log("Game not found - this should not be possible");
      return;
    }

    const decks = [this._game.deck1, this._game.deck2, this._game.deck3];
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
          console.log(
            `${deckName}-badge-${i}`,
            `decks/${deckName}/badge-${i}.png`,
          );
          this.load.image(
            `${deckName}-badge-${i}`,
            `decks/${deckName}/badge-${i}.png`,
          );
        }
      }
    }
    this.load.start();
    await new Promise((resolve) => this.load.on("complete", resolve));

    for (let i = 0; i < decks.length; i++) {
      const deckName = decks[i].name.isCustom
        ? decks[i].name.customName
        : decks[i].name.deckName;
      for (const badge of decks[i].badges) {
        this.add
          .image(
            this.scale.gameSize.width / 4 + 260,
            250 + 150 * i,
            `${deckName}-badge-${badge.points}`,
          )
          .setScale(0.1);
      }
    }

    for (let i = 0; i < this._game.boardTiles.length; i++) {
      this.add
        .image(
          this.scale.gameSize.width / 4 + 150 * ((i % 3) - 1),
          250 + 150 * Math.floor(i / 3),
          `board-${i + 1}`,
        )
        .setScale(0.1);
    }

    for (let i = 0; i < this._game.colorOrder.length; i++) {
      const color = this._game.colorOrder[i];
      const player = Object.values(this._game.players).find(
        (p) => p.color === color,
      );
      if (!player) {
        continue;
      }

      this._meaples[color] = [];
      for (let j = 0; j < 3; j++) {
        const key = ["path1Progress", "path2Progress", "path3Progress"][j] as
          | "path1Progress"
          | "path2Progress"
          | "path3Progress";
        const meaple = this.add
          .image(
            this.scale.gameSize.width / 4 - 237 + player[key] * 25,
            210 + 20 * i + 150 * j,
            `meaple-${color}`,
          )
          .setScale(0.05);
        this._meaples[color].push(meaple);
      }
    }

    // TODO: Add participation/all star badges

    const me = this._game.players[this._playerId];
    this.add
      .image(
        this.scale.gameSize.width / 4,
        this.scale.gameSize.height - 200,
        `board-${me.color}`,
      )
      .setScale(0.1);
    this._decks["drawPile"] = [];
    for (const _ of me.drawPile) {
      const image = this.add
        .image(
          this.scale.gameSize.width / 4 - 142,
          this.scale.gameSize.height - 200,
          "card-back",
        )
        .setScale(0.085);
      this._decks["drawPile"].push(image);
    }

    for (let i = 0; i < decks.length; i++) {
      const deckName = decks[i].name.isCustom
        ? decks[i].name.customName
        : decks[i].name.deckName;
      this.add
        .image(
          this.scale.gameSize.width / 4 + 400,
          250 + 150 * i,
          `${deckName}-${decks[i].storeCards[0].name}`,
        )
        .setScale(0.085);
      this.add
        .image(
          this.scale.gameSize.width / 4 + 520,
          250 + 150 * i,
          `${deckName}-${decks[i].storeCards[1].name}`,
        )
        .setScale(0.085);
      this.add
        .image(this.scale.gameSize.width / 4 + 640, 250 + 150 * i, `card-back`)
        .setScale(0.085);
    }

    this.add
      .image(this.scale.gameSize.width / 4 + 400, 100, `core-Smores`)
      .setScale(0.085);
    this.add
      .image(this.scale.gameSize.width / 4 + 520, 100, `core-Scavenger hunt`)
      .setScale(0.085);
    this.add
      .image(this.scale.gameSize.width / 4 + 640, 100, `core-Free time`)
      .setScale(0.085);
  }

  updateGame() {}

  create() {
    this.add
      .image(this.scale.gameSize.width / 4, 100, "board-top")
      .setScale(0.1);
  }
}
