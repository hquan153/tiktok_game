using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;
    //[SerializeField] private AudioClip bonk;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBonk()
    {
        audioSource.Play();
    }

    public void StopBonk()
    {
        audioSource.Stop();
    }
}
