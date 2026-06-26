using UnityEngine;

public class Message_Handler : MonoBehaviour
{
    private Attack_Manager attackManagerScript;

    private void Awake()
    {
        attackManagerScript = transform.GetComponent<Attack_Manager>();
    }

    public void HandleMessage(string messageJSON)
    {
        Json_Form message = JsonUtility.FromJson<Json_Form>(messageJSON);
        if (message.message == null)
        {
            attackManagerScript.AddAttackQueue(message);
            Debug.Log(message.giftName + " x" + message.count + ", attacker: " + message.attacker + " ");
        }
        else Debug.Log(message.message);
    }
}
