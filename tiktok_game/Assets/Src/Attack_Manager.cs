using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack_Manager : MonoBehaviour
{
    private GameObject ronaldoObject;
    private GameObject messiObject;

    private Player ronaldoScript;
    private Player messiScript;

    private Sound soundComponent;

    private readonly Queue<Json_Form> attackQueue = new Queue<Json_Form>();

    private bool isAttacking = false;

    private void Start()
    {
        ronaldoObject = GameObject.Find("Players/Ronaldo");
        messiObject = GameObject.Find("Players/Messi");

        ronaldoScript = ronaldoObject.GetComponent<Player>();
        messiScript = messiObject.GetComponent<Player>();

        soundComponent = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
    }

    private void Update()
    {
        if (attackQueue.Count > 0 && !isAttacking)
        {
            Json_Form nextAttacker = attackQueue.Dequeue();

            StartCoroutine(ExecuteAttackRoutine(nextAttacker));
        }
    }

    private IEnumerator ExecuteAttackRoutine(Json_Form message)
    {
        isAttacking = true;

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
        soundComponent.PlayBonk();

        yield return new WaitForSeconds(ronaldoScript.restTime);

        isAttacking = false;
    }

    public void AddAttackQueue(Json_Form message)
    {
        for (int i = 0; i < message.count; i++)
        {
            attackQueue.Enqueue(message);
        }
    }
}