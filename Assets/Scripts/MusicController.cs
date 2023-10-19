using UnityEngine;
using FMODUnity;

public class MusicController : MonoBehaviour
{
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
            musicInstance = RuntimeManager.CreateInstance(musicEvent);
            musicInstance.start();
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicInstance.release();
        }
    }
}
