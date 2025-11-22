using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playPauseButton;
    public Slider soundBar;

    void Start()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);

        soundBar.minValue = 0;
        soundBar.maxValue = 1;
        soundBar.value = 0;

        audioSource.playOnAwake = false;
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
        }
        else
        {
            audioSource.Play();
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
