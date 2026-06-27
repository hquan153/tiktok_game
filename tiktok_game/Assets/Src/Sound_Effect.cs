using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.enabled = false;
    }

    public void PlayBonk()
    {
        audioSource.enabled = true;
    }

    public void StopBonk()
    {
        audioSource.enabled = false;
    }
}
