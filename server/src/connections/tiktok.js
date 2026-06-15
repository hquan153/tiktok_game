const { TikTokLiveConnection } = require("tiktok-live-connector");

const constants = require("../untils/constants");

const tiktokUsername = constants.tiktokUsername;
const tiktokConnection = new TikTokLiveConnection(tiktokUsername);

tiktokConnection
  .connect()
  .then((state) => {
    console.info(`Connected to roomId ${state.roomId}`);
  })
  .catch((err) => {
    console.error("Failed to connect", err);
  });

module.exports = tiktokConnection;
