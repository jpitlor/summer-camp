import Phaser, { Scene } from "phaser";
import type { Game } from "../models/game.ts";
import Image = Phaser.GameObjects.Image;
import GameObject = Phaser.GameObjects.GameObject;
import { PreloadGame } from "./scene-preload-game.ts";
import { onClick, onMouseOut, onMouseOver } from "../util/phaser-events.ts";
import { layoutScene } from "../util/phaser-layout.ts";
import Rectangle = Phaser.GameObjects.Rectangle;

function getCssColor(c: string) {
  switch (c) {
    default:
      return 0x000;
    case "Red":
      return 0xef4444;
    case "Green":
      return 0x14b8a6;
    case "Purple":
      return 0xa855f7;
    case "Yellow":
      return 0xeab308;
  }
}

export class PlayGame extends Scene {
  _game?: Game;
  _playerId = localStorage.getItem("playerId")!;
  _board: Image[] = []; // Item 0 is the top, items 1-9 are the tiles
  _meaples: Record<string, Image[]> = {};
  _badges: Record<string, Image[]> = {};
  _decks: Record<string, Image[]> = {};
  _mat?: Image;
  _hand: Image[] = [];
  _statusElements: (Image | Phaser.GameObjects.Text | Rectangle)[] = [];

  _focused?: GameObject;

  constructor() {
    super("PlayGame");
  }

  async setGame(game: Game) {
    const isFirstSet = !this.registry.get("isGamePreloaded");
    this._game = game;
    if (isFirstSet) {
      this.scene.add("PreloadGame", new PreloadGame(this._game), true);
    }
  }

  create() {
    if (!this._game) {
      console.log("Game not found - the website state isn't 'play'");
      return;
    }

    // For iterating later
    const decks = [this._game.deck1, this._game.deck2, this._game.deck3];

    // Create the board
    const boardTop = this.add.image(9999, 0, "board-top").setScale(0.1);
    this._board.push(boardTop);

    for (let i = 0; i < this._game.boardTiles.length; i++) {
      const tile = this.add.image(9999, 0, `board-${i + 1}`).setScale(0.1);
      this._board.push(tile);
    }

    // Create the meaples
    for (let i = 0; i < this._game.colorOrder.length; i++) {
      const color = this._game.colorOrder[i];
      this._meaples[color] = [];
      for (let j = 0; j < 3; j++) {
        const meaple = this.add
          .image(9999, 0, `meaple-${color}`)
          .setScale(0.05);
        this._meaples[color].push(meaple);
      }
    }

    // TODO: Add participation/all star badges

    // Add "my" player board and draw pile
    const me = this._game.players[this._playerId];
    this._mat = this.add.image(9999, 0, `board-${me.color}`).setScale(0.1);
    this._decks["drawPile"] = [];
    for (const _ of me.drawPile) {
      const image = this.add.image(9999, 0, "card-back").setScale(0.085);
      this._decks["drawPile"].push(image);
    }

    // Add hand
    for (const card of me.hand) {
      const image = this.add.image(9999, 0, `${card.deckName}-${card.name}`);
      this._hand.push(image);
    }

    // Add path badges
    for (let i = 0; i < decks.length; i++) {
      const deckName = decks[i].name.isCustom
        ? decks[i].name.customName
        : decks[i].name.deckName;
      this._badges[deckName] = [];
      for (const badge of decks[i].badges) {
        const image = this.add
          .image(9999, 0, `${deckName}-badge-${badge.points}`)
          .setScale(0.1);
        this._badges[deckName].push(image);
      }
    }

    // Add deck stores
    for (let i = 0; i < decks.length; i++) {
      const deckName = decks[i].name.isCustom
        ? decks[i].name.customName
        : decks[i].name.deckName;
      this._decks[deckName] = [];
      const card1 = this.add
        .image(9999, 0, `${deckName}-${decks[i].storeCards[0].name}`)
        .setScale(0.085)
        .setInteractive();
      this._decks[deckName].push(card1);
      const card2 = this.add
        .image(9999, 0, `${deckName}-${decks[i].storeCards[1].name}`)
        .setScale(0.085)
        .setInteractive();
      this._decks[deckName].push(card2);
      const cardX = this.add.image(9999, 0, `card-back`).setScale(0.085);
      this._decks[deckName].push(cardX);
    }

    // Add the core store
    this._decks["core"] = [];
    const smores = this.add
      .image(9999, 0, `core-Smores`)
      .setScale(0.085)
      .setInteractive();
    this._decks["core"].push(smores);
    const scavengerHunt = this.add
      .image(9999, 0, `core-Scavenger hunt`)
      .setScale(0.085)
      .setInteractive();
    this._decks["core"].push(scavengerHunt);
    const freeTime = this.add
      .image(9999, 0, `core-Free time`)
      .setScale(0.085)
      .setInteractive();
    this._decks["core"].push(freeTime);

    // Add UI elements for game status
    const border = this.add.rectangle(9999, 0, 310, 110, 0x000000);
    this._statusElements.push(border);
    const background = this.add.rectangle(9999, 0, 300, 100, 0xffffff);
    this._statusElements.push(background);
    const title = this.add.text(9999, 0, "Player Order", {
      color: "#000",
      fontSize: 12,
      fontFamily: "Arial",
      align: "left",
    });
    this._statusElements.push(title);
    for (let i = 0; i < this._game.colorOrder.length; i++) {
      const color = this._game.colorOrder[i];
      const player = Object.values(this._game.players).find(
        (p) => p.color === color,
      );
      if (!player) {
        continue;
      }

      const cssColor = getCssColor(color);
      const colorBox = this.add.rectangle(9999, 0, 40, 40, cssColor);
      this._statusElements.push(colorBox);
      const name = this.add.text(9999, 0, player.name, {
        color: "#000",
        fontSize: 12,
        fontFamily: "Arial",
        align: "center",
      });
      this._statusElements.push(name);
    }

    // Set correct positions
    const doLayoutScene = layoutScene(this);
    doLayoutScene();

    this.input.on("gameobjectdown", onClick(this));
    this.input.on("gameobjectover", onMouseOver(this));
    this.input.on("gameobjectout", onMouseOut(this));
    this.scale.on("resize", doLayoutScene);
  }
}
