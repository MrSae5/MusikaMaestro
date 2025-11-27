using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Transform panels;
    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private AudioSource otherMusic;

    private void Update()
    {
        Vector3 pos = panels.localPosition;

       
        if (Vector2.Distance(pos, Vector2.zero) < 50f)
        {
            if (!mainMusic.isPlaying)
            {
                otherMusic.Stop();
                mainMusic.Play();
            }
        }
        else
        {
            if (!otherMusic.isPlaying)
            {
                mainMusic.Stop();
                otherMusic.Play();
            }
        }
    }
}

