using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource; // el audio que quieres silenciar

    [Header("UI")]
    public Button button;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private Image buttonImage;
    private bool isSoundOn = true;

    void Awake()
    {
        buttonImage = button.GetComponent<Image>();
        buttonImage.sprite = soundOnSprite; // empieza con sonido activado

        audioSource.mute = false;

        button.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        // Cambia el sprite del botón
        buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;

        // Silencia o activa el audio
        audioSource.mute = !isSoundOn;
    }
}
