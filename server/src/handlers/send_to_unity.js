const app = require("../index");

const sendToUnity = (eventType, giftInfo) => {
  const unityClient = app?.locals?.unityClient;

  if (!unityClient || unityClient.readyState !== WebSocket.OPEN) return;
  unityClient.send(JSON.stringify({ type: eventType, payload: giftInfo }));

  console.log(`[Sent to Unity]: ${giftInfo.giftId} x${giftInfo.repeatCount}`);
};

module.exports = sendToUnity;
