const { TikTokLiveConnection } = require("tiktok-live-connector");
const readline = require("readline");

const constants = require("../untils/constants");

const tiktokUsername = constants.tiktokUsername;
const tiktokConnection = new TikTokLiveConnection(tiktokUsername);

readline.emitKeypressEvents(process.stdin);
if (process.stdin.isRawMode) {
  process.stdin.setRawMode(true);
}

tiktokConnection
  .connect()
  .then((state) => {
    console.info(`Connected to roomId ${state.roomId}`);
  })
  .catch((err) => {
    console.error("Failed to connect", err);
  });

process.stdin.on("keypress", (str, key) => {
  if (key.name === "a") {
    tiktokConnection.emit("gift", {
      order: 15,
      giftId: 9139,
      name: "Gift 15",
      attacker: "Random",
      target: "Random",
      damage: 0,
      from: 0.01,
      to: 0.08,
      diamondCount: 2,
      test: true,
    });
  } else if (key.name === "s") {
    tiktokConnection.emit("gift", {
      order: 1,
      giftId: 5655,
      name: "Gift 1",
      attacker: "Ronaldo",
      target: "Messi",
      damage: 0.01,
      from: 0,
      to: 0,
      diamondCount: 1,
      test: true,
    });
  } else if (key.name === "d") {
    tiktokConnection.emit("gift", {
      order: 8,
      giftId: 5760,
      name: "Gift 8",
      attacker: "Messi",
      target: "Ronaldo",
      damage: 0.01,
      from: 0,
      to: 0,
      diamondCount: 1,
      test: true,
    });
  }
});

module.exports = tiktokConnection;
