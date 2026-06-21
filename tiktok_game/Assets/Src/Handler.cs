using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

public class Handler : MonoBehaviour
{
    [SerializeField] private GameObject ronaldoObject;
    [SerializeField] private GameObject messiObject;

    private Sound soundComponent;

    private Player ronaldoScript;
    private Player messiScript;

    private void Awake()
    {
        soundComponent = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();

        ronaldoScript = ronaldoObject.GetComponent<Player>();
        messiScript = messiObject.GetComponent<Player>();
    }

    private void Update()
    {
        if (Keyboard.current?.aKey.wasPressedThisFrame == true)
        {
            //PlayerAttack();
        }
        else if (Keyboard.current?.dKey.wasPressedThisFrame == true)
        {
            //PlayerAttack("Messi");
        }
    }

    private void PlayerAttack(Json_Form message)
    {
        if (message.attacker == "Ronaldo")
        {
            ronaldoScript.Attack();
            messiScript.Damaged(message.damage != 0 ? message.damage : Random.Range(message.from, message.to));
        }
        else if (message.attacker == "Messi")
        {
            messiScript.Attack();
            ronaldoScript.Damaged(message.damage != 0 ? message.damage : Random.Range(message.from, message.to));
        }
        else
        {
            float randomNumber = Random.Range(-1f, 1f);
            message.attacker = randomNumber <= 0 ? "Ronaldo" : "Messi";
            message.target = randomNumber <= 0 ? "Messi" : "Ronaldo";
            PlayerAttack(message);
        }
        soundComponent.PlayBonk();
    }

    public void HandleMessage(string messageJSON)
    {
        Json_Form message = JsonUtility.FromJson<Json_Form>(messageJSON);
        if (message.message == null) PlayerAttack(message);
        else Debug.Log(message.message);
    }
}
