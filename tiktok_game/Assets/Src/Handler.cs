using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private MonoBehaviour ronaldoScript;
    [SerializeField] private MonoBehaviour messiScript;

    //[SerializeField] private Json_Form jsonForm;

    void Start()
    {

    }

    void Update()
    {

    }

    public void HandleMessage(string message)
    {
        Json_Form test = JsonUtility.FromJson<Json_Form>(message);
        Debug.Log(message + ", " + test.id);

    }
}
