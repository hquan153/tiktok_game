using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack_Manager : MonoBehaviour
{
    private GameObject ronaldoObject;
    private GameObject messiObject;

    private Player ronaldoScript;
    private Player messiScript;

    private Sound soundScript;

    private readonly Queue<Json_Form> attackQueue = new Queue<Json_Form>();

    private bool isAttacking = false;

    private void Awake()
    {
        ronaldoObject = GameObject.Find("Players/Ronaldo");
        messiObject = GameObject.Find("Players/Messi");

        ronaldoScript = ronaldoObject.GetComponent<Player>();
        messiScript = messiObject.GetComponent<Player>();

        soundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
    }

    private void Update()
    {
        if (attackQueue.Count > 0 && !isAttacking)
        {
            soundScript.PlayBonk();
            
            Json_Form nextAttacker = attackQueue.Dequeue();
            StartCoroutine(ExecuteAttackRoutine(nextAttacker));
        }
        else
        {
            //soundScript.StopBonk();
        }
    }

    private IEnumerator ExecuteAttackRoutine(Json_Form message)
    {
        isAttacking = true;

        if (message.attacker == "Ronaldo")
        {
            ronaldoScript.Attack();
            messiScript.Damaged(message.damage);
        }
        else if (message.attacker == "Messi")
        {
            messiScript.Attack();
            ronaldoScript.Damaged(message.damage);
        }

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