import { Scene } from "phaser";

export class PlayGame extends Scene {
  preload() {
    this.load.setPath("/");
    this.load.image("blue-meaple", "blue-meaple.png");
    this.load.image("red-meaple", "red-meaple.png");
    this.load.image("purple-meaple", "purple-meaple.png");
    this.load.image("yellow-meaple", "yellow-meaple.png");
    this.load.spritesheet("board", "board.png", {
      frameWidth: 236,
      frameHeight: 225,
    });
    this.load.spritesheet("player-board", "player-boards.png", {
      frameWidth: 600,
      frameHeight: 241,
    });
  }

  create() {
    const tile = [0, 1, 2, 3, 4, 5, 6, 7, 8];
    for (let i = 0; i < 9; i++) {
      const tileIndex = Math.floor(Math.random() * tile.length);
      const [t] = tile.splice(tileIndex, 1);
      this.add.image(
        200 + 236 * (i % 3),
        200 + 225 * Math.floor(i / 3),
        "board",
        t,
      );
    }

    for (let i = 0; i < 3; i++) {
      const m1 = this.add.image(110, 140 + 225 * i, "blue-meaple");
      const m2 = this.add.image(110, 165 + 225 * i, "red-meaple");
      const m3 = this.add.image(110, 190 + 225 * i, "purple-meaple");
      const m4 = this.add.image(110, 215 + 225 * i, "yellow-meaple");
      this.add.group([m1, m2, m3, m4], { name: `track${i}` });
    }

    this.add.sprite(
      window.innerWidth / 2 - 300,
      window.innerHeight - 450,
      "player-board",
      Math.floor(Math.random() * 4),
    );
  }
}
