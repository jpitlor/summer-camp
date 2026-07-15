import Phaser from "phaser";

const colors = ["Red", "Green", "Purple", "Yellow"];

export class PreloadCommon extends Phaser.Scene {
  constructor() {
    super("PreloadCommon");
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

    this.scene.start("PlayGame");
  }
}
