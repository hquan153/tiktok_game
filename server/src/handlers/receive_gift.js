const { TikTokLiveConnection, WebcastEvent } = require("tiktok-live-connector");

const tiktokConnection = require("../connections/tiktok");

const sendToUnity = require("./send_to_unity");

const constants = require("../untils/constants");

tiktokConnection.on(WebcastEvent.GIFT, (data) => {
  /* console.log(
    `${data.user.uniqueId} sends ${data.giftId}, ${data.giftDetails.giftName}, repeatCount: ${data.repeatCount}`,
  ); */

  const giftInfo = {
    // userId: data.user.uniqueId,
    giftId: data.giftId,
    // giftName: data.giftDetails.giftName,
    repeatCount: data.repeatCount,
  };

  sendToUnity("GIFT", giftInfo);
});
