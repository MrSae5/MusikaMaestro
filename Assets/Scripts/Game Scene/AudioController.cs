using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playPauseButton;
    public Slider soundBar;

    public Sprite playSprite;
    public Sprite pauseSprite;
    private Image buttonImage;

    void Start()
    {

        buttonImage = playPauseButton.GetComponent<Image>();
        buttonImage.sprite = playSprite;  // empieza en modo Play

        playPauseButton.onClick.AddListener(TogglePlayPause);

        soundBar.minValue = 0;
        soundBar.maxValue = 1;
        soundBar.value = 0;

        
    }

    void Update()
    {
        if (audioSource.clip != null)
        {
            if (audioSource.isPlaying)
            {
                soundBar.value = audioSource.time / audioSource.clip.length;
            }
            
        }
    }

    public void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            buttonImage.sprite = playSprite; // aquí cambia a play
        }
        else
        {
            audioSource.Play();
            buttonImage.sprite = pauseSprite; // aquí cambia a pause
        }
    }

    public void OnSliderChanged()
    {
        if (audioSource.clip != null)
        {
            audioSource.time = soundBar.value * audioSource.clip.length;
        }
    }
}

