using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Handler : MonoBehaviour
{
    [SerializeField] private Gift_Info giftInfo;

    [SerializeField] private GameObject ronaldoObject;
    [SerializeField] private GameObject messiObject;

    private Sound soundObject;

    private Player ronaldoScript;
    private Player messiScript;

    private List<int> messiGift = new List<int>();

    private void Start()
    {
        soundObject = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();

        ronaldoScript = ronaldoObject.GetComponent<Player>();
        messiScript = messiObject.GetComponent<Player>();

        Debug.Log(giftInfo);
        foreach(var gift in giftInfo.messi)
        {
            messiGift.Add(gift.id);
        }
    }

    private void Update()
    {
        if (Keyboard.current?.aKey.wasPressedThisFrame == true)
        {
            ronaldoScript.Attack();
            messiScript.Damaged(0.1f);
            soundObject.PlayBonk();
        }
        else if (Keyboard.current?.dKey.wasPressedThisFrame == true)
        {
            messiScript.Attack();
            ronaldoScript.Damaged(0.1f);
            soundObject.PlayBonk();
        }
    }

    public void HandleMessage(string message)
    {
        Json_Form test = JsonUtility.FromJson<Json_Form>(message);
        Debug.Log(message + ", " + test.id);

        foreach (var gift in giftInfo.messi)
        {
            Debug.Log(gift);
        }

    }
}
