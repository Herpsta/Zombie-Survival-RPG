using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Event reference for the zombie growl sound")]
    public EventReference zombieGrowlEvent;

    // TODO: Add more EventReference variables for other sound effects

    void Start()
    {
        // This will play the sound when the scene starts
        PlayZombieGrowl();
    }

    public void PlayZombieGrowl()
    {
        // Check if the event reference is not null
        if (zombieGrowlEvent != null)
        {
            Debug.Log("Attempting to play event: " + zombieGrowlEvent);
            RuntimeManager.PlayOneShot(zombieGrowlEvent, transform.position);
        }
        else
        {
            Debug.LogError("Zombie growl event reference is null. Please assign it in the inspector.");
        }
    }

    // TODO: Implement methods to play other sound effects

    // Method to stop all sounds
    public void StopAllSounds()
    {
        RuntimeManager.StopAll();
    }

    // Method to pause all sounds
    public void PauseAllSounds()
    {
        RuntimeManager.PauseAll();
    }

    // Method to resume all sounds
    public void ResumeAllSounds()
    {
        RuntimeManager.ResumeAll();
    }
}