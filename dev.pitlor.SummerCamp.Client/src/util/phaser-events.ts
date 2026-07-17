import type { PlayGame } from "../scenes/scene-play-game.ts";
import Phaser from "phaser";
import Pointer = Phaser.Input.Pointer;
import GameObject = Phaser.GameObjects.GameObject;

export const onClick =
  (scene: PlayGame) => (_pointer: Pointer, gameObject: GameObject) => {
    if (gameObject.getData("isBackdrop") && scene._focused) {
      gameObject.destroy();
      scene.tweens.add({
        targets: scene._focused,
        scale: { value: 0.085, duration: 200 },
        x: { value: scene._focused.getData("x"), duration: 200 },
        y: { value: scene._focused.getData("y"), duration: 200 },
      });
      scene._focused.setData("isFocused", false);
      scene._focused = undefined;
      return;
    }

    if (gameObject.getData("isFocused")) {
      return;
    }

    scene.add
      .rectangle(
        scene.scale.gameSize.width / 2,
        scene.scale.gameSize.height / 2,
        scene.scale.gameSize.width,
        scene.scale.gameSize.height,
        0x000,
        0.3,
      )
      .setData("isBackdrop", true)
      .setInteractive();
    // scene.add
    //   .text(scene.scale.gameSize.width - 100, 50, "X", { fontSize: 42 })
    //   .setData("isBackdrop", true)
    //   .setInteractive();
    scene._focused = gameObject
      .setData("isFocused", true)
      .setData("x", (gameObject as any).x)
      .setData("y", (gameObject as any).y); // TODO figure out why TS doesn't like scene
    scene.children.bringToTop(gameObject);
    scene.tweens.add({
      targets: gameObject,
      scale: {
        value: (scene.scale.gameSize.height * 0.8) / 1500,
        duration: 200,
      },
      x: { value: scene.scale.gameSize.width / 2, duration: 200 },
      y: { value: scene.scale.gameSize.height / 2, duration: 200 },
    });
  };

export const onMouseOver =
  (scene: PlayGame) => (_pointer: Pointer, gameObject: GameObject) => {
    if (gameObject.getData("isBackdrop") || gameObject.getData("isFocused")) {
      return;
    }

    scene.tweens.add({
      targets: gameObject,
      scale: { value: 0.1, duration: 200 },
    });
  };

export const onMouseOut =
  (scene: PlayGame) => (_pointer: Pointer, gameObject: GameObject) => {
    if (gameObject.getData("isBackdrop") || gameObject.getData("isFocused")) {
      return;
    }

    scene.tweens.add({
      targets: gameObject,
      scale: { value: 0.085, duration: 200 },
    });
  };
