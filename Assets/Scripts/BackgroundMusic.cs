using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    public AudioClip backgroundMusic;

    private AudioSource musicSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.playOnAwake = false;
            musicSource.volume = 1.3f;

            if (backgroundMusic != null && !musicSource.isPlaying)
                musicSource.Play();

            Debug.Log("BackgroundMusic: Instance created and music started.");
        }
        else if (Instance != this)
        {
            Debug.Log("BackgroundMusic: Duplicate destroyed.");
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = Mathf.Clamp01(volume);
    }
}