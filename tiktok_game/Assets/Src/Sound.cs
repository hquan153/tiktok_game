using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bonk;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBonk()
    {
        audioSource.PlayOneShot(bonk);
    }
}
