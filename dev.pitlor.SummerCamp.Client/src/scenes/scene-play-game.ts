import Phaser, { Scene } from "phaser";
import type { Game } from "../models/game.ts";
import Image = Phaser.GameObjects.Image;
import GameObject = Phaser.GameObjects.GameObject;
import Pointer = Phaser.Input.Pointer;
import { PreloadGame } from "./scene-preload-game.ts";

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
  _meaples: Record<string, Image[]> = {};
  _badges: Record<string, Image[]> = {};
  _decks: Record<string, Image[]> = {};

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
      console.log(
        "Game not found - this probably means the scene has loaded, but the website state isn't 'play'",
      );
      return;
    }

    const decks = [this._game.deck1, this._game.deck2, this._game.deck3];

    this.add
      .image(this.scale.gameSize.width / 4, 100, "board-top")
      .setScale(0.1);

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
          this.scale.gameSize.height - 201,
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
        .setScale(0.085)
        .setInteractive();
      this.add
        .image(
          this.scale.gameSize.width / 4 + 520,
          250 + 150 * i,
          `${deckName}-${decks[i].storeCards[1].name}`,
        )
        .setScale(0.085)
        .setInteractive();
      this.add
        .image(this.scale.gameSize.width / 4 + 640, 250 + 150 * i, `card-back`)
        .setScale(0.085);
    }

    this.add
      .image(this.scale.gameSize.width / 4 + 400, 100, `core-Smores`)
      .setScale(0.085)
      .setInteractive();
    this.add
      .image(this.scale.gameSize.width / 4 + 520, 100, `core-Scavenger hunt`)
      .setScale(0.085)
      .setInteractive();
    this.add
      .image(this.scale.gameSize.width / 4 + 640, 100, `core-Free time`)
      .setScale(0.085)
      .setInteractive();

    this.add.rectangle(
      this.scale.gameSize.width - 320,
      this.scale.gameSize.height - 120,
      310,
      110,
      0x000000,
    );
    this.add.rectangle(
      this.scale.gameSize.width - 320,
      this.scale.gameSize.height - 120,
      300,
      100,
      0xffffff,
    );
    this.add.text(
      this.scale.gameSize.width - 460,
      this.scale.gameSize.height - 160,
      "Player Order",
      { color: "#000", fontSize: 12, fontFamily: "Arial", align: "left" },
    );
    for (let i = 0; i < this._game.colorOrder.length; i++) {
      const color = this._game.colorOrder[i];
      const player = Object.values(this._game.players).find(
        (p) => p.color === color,
      );
      if (!player) {
        continue;
      }

      const cssColor = getCssColor(color);
      this.add.rectangle(
        this.scale.gameSize.width - 440 + 30 * i,
        this.scale.gameSize.height - 120,
        40,
        40,
        cssColor,
      );
      this.add.text(
        this.scale.gameSize.width - 440 + 30 * i,
        this.scale.gameSize.height - 90,
        player.name,
        { color: "#000", fontSize: 12, fontFamily: "Arial", align: "center" },
      );
    }

    this.input.on(
      "gameobjectdown",
      (_pointer: Pointer, gameObject: GameObject) => {
        if (gameObject.getData("isBackdrop") && this._focused) {
          gameObject.destroy();
          this.tweens.add({
            targets: this._focused,
            scale: { value: 0.085, duration: 200 },
            x: { value: this._focused.getData("x"), duration: 200 },
            y: { value: this._focused.getData("y"), duration: 200 },
          });
          this._focused.setData("isFocused", false);
          this._focused = undefined;
          return;
        }

        if (gameObject.getData("isFocused")) {
          return;
        }

        this.add
          .rectangle(
            this.scale.gameSize.width / 2,
            this.scale.gameSize.height / 2,
            this.scale.gameSize.width,
            this.scale.gameSize.height,
            0x000,
            0.3,
          )
          .setData("isBackdrop", true)
          .setInteractive();
        // this.add
        //   .text(this.scale.gameSize.width - 100, 50, "X", { fontSize: 42 })
        //   .setData("isBackdrop", true)
        //   .setInteractive();
        this._focused = gameObject
          .setData("isFocused", true)
          .setData("x", (gameObject as any).x)
          .setData("y", (gameObject as any).y); // TODO figure out why TS doesn't like this
        console.log(gameObject);
        this.children.bringToTop(gameObject);
        this.tweens.add({
          targets: gameObject,
          scale: { value: 0.75, duration: 200 },
          x: { value: this.scale.gameSize.width / 2, duration: 200 },
          y: { value: this.scale.gameSize.height / 2, duration: 200 },
        });
      },
    );

    this.input.on(
      "gameobjectover",
      (_pointer: Pointer, gameObject: GameObject) => {
        if (
          gameObject.getData("isBackdrop") ||
          gameObject.getData("isFocused")
        ) {
          return;
        }

        this.tweens.add({
          targets: gameObject,
          scale: { value: 0.1, duration: 200 },
        });
      },
    );

    this.input.on(
      "gameobjectout",
      (_pointer: Pointer, gameObject: GameObject) => {
        if (
          gameObject.getData("isBackdrop") ||
          gameObject.getData("isFocused")
        ) {
          return;
        }

        this.tweens.add({
          targets: gameObject,
          scale: { value: 0.085, duration: 200 },
        });
      },
    );
  }
}
