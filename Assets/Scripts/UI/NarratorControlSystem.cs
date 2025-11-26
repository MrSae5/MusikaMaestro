using UnityEngine;
using UnityEngine.UI;

public class NarratorControlSystem : MonoBehaviour
{
    [Header("Pantallas y audios")]
    public GameObject[] screens;        // Todos los objetos de pantalla
    public AudioSource[] screenAudios;  // Audio correspondiente a cada pantalla
    public Toggle toggle;               // Toggle general para activar/desactivar audios

    // Llama esto cuando cambias de pantalla
    public void ShowScreen(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            bool isActive = (i == index);
            screens[i].SetActive(isActive);

            if (toggle.isOn && isActive)
            {
                if (!screenAudios[i].isPlaying)
                    screenAudios[i].Play();
            }
            else
            {
                if (screenAudios[i].isPlaying)
                    screenAudios[i].Stop();
            }
        }
    }

    // Llama esto si se cambia el toggle mientras la pantalla está activa
    public void OnToggleChanged()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].activeSelf)
            {
                if (toggle.isOn)
                    screenAudios[i].Play();
                else
                    screenAudios[i].Stop();
            }
        }
    }

}
