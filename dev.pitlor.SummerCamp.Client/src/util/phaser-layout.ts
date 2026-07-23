import type { PlayGame } from "../scenes/scene-play-game.ts";

const SPACE_WIDTH = 25;

export const layoutScene = (scene: PlayGame) => () => {
  if (!scene._game) {
    // Shouldn't be possible
    return;
  }

  // For iterating later
  const decks = [scene._game.deck1, scene._game.deck2, scene._game.deck3];

  // Create the board
  scene._board[0].setX(scene.scale.gameSize.width / 4);
  scene._board[0].setY(100);

  for (let i = 1; i < scene._board.length; i++) {
    const column = (i - 1) % 3;
    const row = Math.floor((i - 1) / 3);
    scene._board[i].setX(scene.scale.gameSize.width / 4 + 150 * (column - 1));
    scene._board[i].setY(250 + 150 * row);
  }

  // Create the meaples
  for (let i = 0; i < scene._game.colorOrder.length; i++) {
    const color = scene._game.colorOrder[i];
    const player = Object.values(scene._game.players).find(
      (p) => p.color === color,
    );
    if (!player) {
      continue;
    }

    for (let j = 0; j < 3; j++) {
      const key = ["path1Progress", "path2Progress", "path3Progress"][j] as
        | "path1Progress"
        | "path2Progress"
        | "path3Progress";
      scene._meaples[color][j].setX(
        scene.scale.gameSize.width / 4 - 237 + player[key] * SPACE_WIDTH,
      );
      scene._meaples[color][j].setY(210 + 20 * i + 150 * j);
    }
  }

  // TODO: Add participation/all star badges

  // Add "my" player board and draw pile
  scene._mat?.setX(scene.scale.gameSize.width / 4);
  scene._mat?.setY(scene.scale.gameSize.height - 200);

  for (const card of scene._decks["drawPile"]) {
    card.setX(scene.scale.gameSize.width / 4 - 142);
    card.setY(scene.scale.gameSize.height - 201);
  }

  // Add path badges
  for (let i = 0; i < decks.length; i++) {
    const deckName = decks[i].name.isCustom
      ? decks[i].name.customName
      : decks[i].name.deckName;
    for (const badge of scene._badges[deckName]) {
      badge.setX(scene.scale.gameSize.width / 4 + 260);
      badge.setY(250 + 150 * i);
    }
  }

  // Add deck stores
  for (let i = 0; i < decks.length; i++) {
    const deckName = decks[i].name.isCustom
      ? decks[i].name.customName
      : decks[i].name.deckName;
    for (let j = 0; j < scene._decks[deckName].length; j++) {
      const card = scene._decks[deckName][j];
      card.setX(scene.scale.gameSize.width / 4 + 400 + 120 * j);
      card.setY(250 + 150 * i);
    }
  }

  // Add the core store
  for (let i = 0; i < scene._decks["core"].length; i++) {
    const card = scene._decks["core"][i];
    card.setX(scene.scale.gameSize.width / 4 + 400 + 120 * i);
    card.setY(100);
  }

  // Add UI elements for game status'
  scene._statusElements[0].setX(scene.scale.gameSize.width - 320);
  scene._statusElements[0].setY(scene.scale.gameSize.height - 120);
  scene._statusElements[1].setX(scene.scale.gameSize.width - 320);
  scene._statusElements[1].setY(scene.scale.gameSize.height - 120);
  scene._statusElements[2].setX(scene.scale.gameSize.width - 460);
  scene._statusElements[2].setY(scene.scale.gameSize.height - 160);
  for (let i = 3; i < scene._statusElements.length; i += 2) {
    scene._statusElements[i].setX(scene.scale.gameSize.width - 440 + 30 * i);
    scene._statusElements[i].setY(scene.scale.gameSize.height - 120);
    scene._statusElements[i + 1].setX(
      scene.scale.gameSize.width - 440 + 30 * i,
    );
    scene._statusElements[i + 1].setY(scene.scale.gameSize.height - 90);
  }
};
