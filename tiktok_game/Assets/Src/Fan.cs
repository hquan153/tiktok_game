using UnityEngine;
using UnityEngine.UI;

public class Fan : MonoBehaviour
{
    private Sprite[] sprites;
    private Image imageComponent;

    [SerializeField] private bool isDelay = false;
    private readonly float cheerTime = .4f;

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>($"Fans/{transform.name}");

        imageComponent = transform.GetComponent<Image>();
        imageComponent.sprite = sprites[0];

        InvokeRepeating(nameof(Cheer), isDelay ? cheerTime * 2 : cheerTime, cheerTime);
    }

    private void Cheer()
    {
        imageComponent.sprite = imageComponent.sprite.name.Contains("0") ? sprites[1] : sprites[0];
    }
}
