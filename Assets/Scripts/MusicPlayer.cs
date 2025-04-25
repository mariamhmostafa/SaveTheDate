using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
