using UnityEngine;

public class Action : MonoBehaviour
{
    private GameObject restObject;
    private GameObject attackObject;

    private void Start()
    {
        restObject = transform.Find("Rest").gameObject;
        attackObject = transform.Find("Attack").gameObject;

        //InvokeRepeating("Act", 1f, 1f);
    }

    private void Rest()
    {
        restObject.SetActive(true);
        attackObject.SetActive(false);
    }

    public void Act()
    {
        restObject.SetActive(false);
        attackObject.SetActive(true);

        Invoke("Rest", 0.2f);
    }
}
