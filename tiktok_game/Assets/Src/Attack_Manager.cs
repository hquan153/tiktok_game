using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackManager : MonoBehaviour
{
    private GameObject ronaldoObject;
    private GameObject messiObject;

    private Player ronaldoScript;
    private Player messiScript;

    private SoundEffect soundEffectScript;

    private readonly Queue<JsonForm> attackQueue = new();

    private bool isAttacking = false;

    private void Awake()
    {
        ronaldoObject = GameObject.Find("Players/Ronaldo");
        messiObject = GameObject.Find("Players/Messi");

        ronaldoScript = ronaldoObject.GetComponent<Player>();
        messiScript = messiObject.GetComponent<Player>();

        soundEffectScript = GameObject.FindGameObjectWithTag("Sound Effect").GetComponent<SoundEffect>();
    }

    private void Update()
    {
        if (attackQueue.Count > 0 && !isAttacking)
        {
            JsonForm nextAttacker = attackQueue.Dequeue();
            StartCoroutine(ExecuteAttackRoutine(nextAttacker));
        }
    }

    private IEnumerator ExecuteAttackRoutine(JsonForm message)
    {
        isAttacking = true;
        soundEffectScript.StopBonk();
        soundEffectScript.PlayBonk();

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
        soundEffectScript.StopBonk();
    }

    public void AddAttackQueue(JsonForm message)
    {
        for (int i = 0; i < message.count; i++)
        {
            attackQueue.Enqueue(message);
        }
    }
}