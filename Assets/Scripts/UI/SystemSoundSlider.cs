using UnityEngine;
using UnityEngine.UI;

public class SystemSoundSlider : MonoBehaviour
{
    public AudioSource audioSource;
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
