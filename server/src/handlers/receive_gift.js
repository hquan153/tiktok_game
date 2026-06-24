const { TikTokLiveConnection, WebcastEvent } = require("tiktok-live-connector");

const tiktokConnection = require("../connections/tiktok");

const sendToUnity = require("./send_to_unity");

const constants = require("../untils/constants");
const giftConfig = require("../untils/gift_config");
// console.log(giftConfig);

const allName = giftConfig.map((gift) => gift.giftName);
// console.log(allName);

tiktokConnection.on(WebcastEvent.GIFT, (data) => {
  // console.log(data);
  console.log(`${data.giftDetails.giftName} x${data.repeatCount}, ${data.test}`);

  const index = allName.indexOf(data.giftDetails.giftName);
  if (index === -1) {
    console.log(`Gift name ${data.giftDetails.giftName} not found in giftConfig.`);
    return;
  }

  const giftInfo = { ...giftConfig[index] };
  // console.log(giftInfo);

  if (giftInfo.winTimes > 0) {
    for (let i = 0; i < giftInfo.winTimes; i++) {
      giftInfo.damage = 1;
      sendToUnity({ ...giftInfo, count: 1 });
    }
    return;
  }

  sendToUnity({ ...giftInfo, count: data.test ? 2 : data.repeatCount });
});
