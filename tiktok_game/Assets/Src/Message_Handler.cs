using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    private AttackManager attackManagerScript;

    private void Awake()
    {
        attackManagerScript = transform.GetComponent<AttackManager>();
    }

    public void HandleMessage(string messageJSON)
    {
        JsonForm message = JsonUtility.FromJson<JsonForm>(messageJSON);
        if (message.message == null)
        {
            attackManagerScript.AddAttackQueue(message);
            //Debug.Log(message.giftName + " x" + message.count + ", attacker: " + message.attacker + " ");
        }
        else Debug.Log(message.message);
    }
}
