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
        // Solo activa la pantalla que quieres mostrar
        screens[index].SetActive(true);

        // Recorre todos los paneles para manejar los audios
        for (int i = 0; i < screens.Length; i++)
        {
            bool isActive = screens[i].activeSelf;

            if (toggle.isOn && i == index)
            {
                // Reproduce el audio del panel actual si el toggle está activado
                if (!screenAudios[i].isPlaying)
                    screenAudios[i].Play();
            }
            else
            {
                // Detiene el audio de los otros paneles
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
