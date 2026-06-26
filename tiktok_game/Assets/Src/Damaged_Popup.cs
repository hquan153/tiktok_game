using UnityEngine;

public class Damaged_Popup : MonoBehaviour
{
    private Animator animator;
    private string animationClipName;

    private readonly float lifeTime = .3f;

    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
        animationClipName = animator.runtimeAnimatorController.name;
    }

    private void OnEnable()
    {
        animator.Play(animationClipName, 0, 0f);

        CancelInvoke(nameof(HideObject));
        Invoke(nameof(HideObject), lifeTime);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(HideObject));
    }
}
