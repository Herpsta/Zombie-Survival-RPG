using UnityEngine;
using FMODUnity;

public class MusicController : MonoBehaviour
{
    [Tooltip("FMOD event path for the music")]
    public string musicEvent = "event:/Events/Music/MainMenu";  // Replace with your actual FMOD event path

    private FMOD.Studio.EventInstance musicInstance;

    // Singleton instance
    public static MusicController Instance;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of the music controller exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Instance == this)
        {
            PlayMusic();
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            StopMusic();
        }
    }

    // Function to play music
    public void PlayMusic()
    {
        // Create an instance of the music event
        musicInstance = RuntimeManager.CreateInstance(musicEvent);
        // Start the music event
        musicInstance.start();
    }

    // Function to stop music
    public void StopMusic()
    {
        // Stop the music event with a fade out
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        // Release the music event instance
        musicInstance.release();
    }

    // TODO: Add functions to control the volume, pitch, etc. of the music
}