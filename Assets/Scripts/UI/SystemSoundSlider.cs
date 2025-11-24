using UnityEngine;
using UnityEngine.UI;

public class SystemSoundSlider : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("UI")]
    public Slider slider;

    void Start()
    {
        slider.value = audioSource.volume;
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        audioSource.volume = value;
    }
}
