using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Awake()
    {
        // Make sure this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);
    }
}
