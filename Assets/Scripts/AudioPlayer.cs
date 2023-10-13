using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip audioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
