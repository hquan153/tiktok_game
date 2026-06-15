const app = require("../index");

const sendToUnity = ({ id, count }) => {
  const unityClient = app?.locals?.unityClient;

  if (!unityClient || unityClient.readyState !== WebSocket.OPEN) return;
  unityClient.send(JSON.stringify({ id, count }));

  console.log(`[Sent to Unity]: ${id} x${count}`);
};

module.exports = sendToUnity;
