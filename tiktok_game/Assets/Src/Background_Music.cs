using UnityEngine;
using UnityEngine.InputSystem;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            audioSource.enabled = !audioSource.enabled;
        }
    }
}
