using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private GameObject restObject;
    private GameObject restDamagedObject;
    private GameObject attackObject;

    [SerializeField] private GameObject hpBarOject;
    private Slider hpBar;
    private Image hpBarFill;

    [SerializeField] private GameObject enemyScoreGameObject;
    private TMP_Text enemyScoreComponent;

    private static readonly float attackTime = .2f;
    public float restTime = attackTime;

    private void Start()
    {
        restObject = transform.Find("Rest").gameObject;
        restDamagedObject = transform.Find("Rest Damaged").gameObject;
        attackObject = transform.Find("Attack").gameObject;

        hpBar = hpBarOject.GetComponent<Slider>();
        hpBar.value = 1;
        hpBarFill = hpBarOject.transform.Find("Fill").GetComponent<Image>();

        enemyScoreComponent = enemyScoreGameObject.GetComponent<TMP_Text>();

        restObject.SetActive(true);
        restDamagedObject.SetActive(false);
        attackObject.SetActive(false);
    }

    private void ChangeColorHpBar()
    {
        if (hpBar.value >= .7) hpBarFill.color = Color.green;
        else if (hpBar.value < .7 && hpBar.value >= .3) hpBarFill.color = Color.yellow;
        else hpBarFill.color = Color.red;
    }

    private void Dead()
    {
        if (hpBar.value <= 0)
        {
            enemyScoreComponent.text = (int.Parse(enemyScoreComponent.text) + 1).ToString();
            hpBar.value = 1;
        }
    }

    private void Rest()
    {
        restObject.SetActive(true);
        restDamagedObject.SetActive(false);
        attackObject.SetActive(false);
    }

    public void Attack()
    {
        restObject.SetActive(false);
        //restDamagedObject.SetActive(false);
        attackObject.SetActive(true);

        Invoke("Rest", attackTime);
    }

    public void Damaged(float damage)
    {
        restObject.SetActive(false);
        restDamagedObject.SetActive(true);
        //attackObject.SetActive(false);

        hpBar.value -= damage;
        Dead();
        ChangeColorHpBar();

        Invoke("Rest", attackTime);
    }
}
