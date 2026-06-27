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
      order: 1,
      giftDetails: { giftName: "GG" },
      attacker: "Ronaldo",
      target: "Messi",
      damage: 0.01,
      diamondCount: 1,
      test: true,
    });
  } else if (key.name === "s") {
    tiktokConnection.emit("gift", {
      order: 2,
      giftDetails: { giftName: "Rosa" },
      attacker: "Ronaldo",
      target: "Messi",
      damage: 0.1,
      diamondCount: 10,
      test: true,
    });
  } else if (key.name === "d") {
    tiktokConnection.emit("gift", {
      order: 3,
      giftDetails: { giftName: "Confetti" },
      name: "Confetti",
      attacker: "Ronaldo",
      target: "Messi",
      damage: 5,
      diamondCount: 100,
      test: true,
    });
  } else if (key.name === "g") {
    tiktokConnection.emit("gift", {
      order: 4,
      giftDetails: { giftName: "Rose" },
      attacker: "Messi",
      target: "Ronaldo",
      damage: 0.01,
      diamondCount: 1,
      test: true,
    });
  } else if (key.name === "h") {
    tiktokConnection.emit("gift", {
      order: 5,
      giftDetails: { giftName: "Lucky Pig" },
      attacker: "Messi",
      target: "Ronaldo",
      damage: 0.1,
      diamondCount: 10,
      test: true,
    });
  } else if (key.name === "j") {
    tiktokConnection.emit("gift", {
      order: 6,
      giftDetails: { giftName: "Mini Star" },
      attacker: "Messi",
      target: "Ronaldo",
      damage: 5,
      diamondCount: 100,
      test: true,
    });
  }
});

module.exports = tiktokConnection;
