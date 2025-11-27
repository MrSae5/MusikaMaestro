using UnityEngine;
using UnityEngine.UI;

public class NarratorControlSystem : MonoBehaviour
{
    [Header("Pantallas y audios")]
    public GameObject[] screens;        // Todos los objetos de pantalla
    public AudioSource[] screenAudios;  // Audio correspondiente a cada pantalla
    public Toggle toggle;               // Toggle general para activar/desactivar audios

    // Se llama al cambiar de pantalla
    public void ShowScreen(int index)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            bool isActive = (i == index);
            screens[i].SetActive(isActive);

            if (toggle.isOn && isActive)
            {
                screenAudios[i].Play();
            }
            else
            {
                screenAudios[i].Stop();
            }
        }
    }

    // Se llama cuando cambia el toggle
    public void OnToggleChanged()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].activeSelf)   // Solo la pantalla activa
            {
                if (toggle.isOn)
                    screenAudios[i].Play();
                else
                    screenAudios[i].Stop();
            }
            else
            {
                screenAudios[i].Stop(); // Seguridad: nunca suene una pantalla oculta
            }
        }
    }

}
