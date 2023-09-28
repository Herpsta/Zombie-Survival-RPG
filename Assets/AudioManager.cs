using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public EventReference zombieGrowlEvent;


    void Start()
    {
        PlayZombieGrowl();  // This will play the sound when the scene starts
    }


    public void PlayZombieGrowl()
    {
        Debug.Log("Attempting to play event: " + zombieGrowlEvent);
        RuntimeManager.PlayOneShot(zombieGrowlEvent, transform.position);
    }

}
