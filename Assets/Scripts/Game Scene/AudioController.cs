using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("UI")]
    public Button playPauseButton;
    public Slider soundBar;

    [Header("Icons")]
    public GameObject pauseIcon;   // hijo del botón
    public GameObject playIcon;    // hijo del botón

    void Awake()
    {
        playPauseButton.onClick.AddListener(TogglePlayPause);

        soundBar.minValue = 0;
        soundBar.maxValue = 1;
        soundBar.value = 0;

        audioSource.playOnAwake = false;

        // Mostrar pause al inicio si el audio está listo para reproducir
        pauseIcon.SetActive(true);
        playIcon.SetActive(false);
    }

    void Update()
    {
        if (audioSource.clip != null)
        {
            // Actualizar barra mientras suena
            if (audioSource.isPlaying)
                soundBar.value = audioSource.time / audioSource.clip.length;

            // Cuando termina el audio, mostrar Play y asegurarse de que está pausado
            if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
            {
                pauseIcon.SetActive(false);
                playIcon.SetActive(true);
            }
        }
    }

    public void TogglePlayPause()
    {
        if (audioSource.clip == null) return;

        if (audioSource.isPlaying)
        {
            // Pausar audio
            audioSource.Pause();
            pauseIcon.SetActive(false);
            playIcon.SetActive(true);
        }
        else
        {
            // Reanudar o reproducir desde el principio si terminó
            if (audioSource.time >= audioSource.clip.length)
                audioSource.time = 0;

            audioSource.Play();
            pauseIcon.SetActive(true);
            playIcon.SetActive(false);
        }
    }

    public void OnSliderChanged()
    {
        if (audioSource.clip != null)
            audioSource.time = soundBar.value * audioSource.clip.length;
    }
}
