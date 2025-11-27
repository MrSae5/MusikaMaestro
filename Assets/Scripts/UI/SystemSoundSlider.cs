using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SystemSoundSlider : MonoBehaviour
{
    public GameObject[] audioSourceObjects;  // array de GameObjects que contienen AudioSources
    public Slider slider;

    private List<AudioSource> sources = new List<AudioSource>();

    void Start()
    {
        // Agregar todos los AudioSources de cada GameObject
        foreach (var obj in audioSourceObjects)
        {
            if (obj != null)
            {
                AudioSource[] comps = obj.GetComponents<AudioSource>();
                sources.AddRange(comps);
            }
        }

        // Iniciar slider con el volumen del primer AudioSource
        if (sources.Count > 0)
            slider.value = sources[0].volume;

        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        foreach (var src in sources)
        {
            if (src != null)
                src.volume = value;
        }
    }
}


