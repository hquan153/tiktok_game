using UnityEngine;

public class DamagedPopup : MonoBehaviour
{
    private Animator animator;
    private string animationClipName;

    private readonly float lifeTime = .3f;

    private void Awake()
    {
        animator = transform.GetComponent<Animator>();
        animationClipName = animator.runtimeAnimatorController.name;
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        animator.Play(animationClipName, 0, 0f);

        CancelInvoke(nameof(HideObject));
        Invoke(nameof(HideObject), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(HideObject));
    }
}
