const { TikTokLiveConnection } = require("tiktok-live-connector");
const readline = require("readline");

const constants = require("../untils/constants");

const tiktokUsername = constants.tiktokUsername;
const tiktokConnection = new TikTokLiveConnection(tiktokUsername);

readline.emitKeypressEvents(process.stdin);
if (process.stdin.isRawMode) {
  process.stdin.setRawMode(true);
}

/* tiktokConnection
  .connect()
  .then((state) => {
    console.info(`Connected to roomId ${state.roomId}`);
  })
  .catch((err) => {
    console.error("Failed to connect", err);
  }); */

process.stdin.on("keypress", (str, key) => {
  if (key.name === "r") {
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
    });
  } else if (key.name === "q") {
    process.exit();
  }
});

module.exports = tiktokConnection;
