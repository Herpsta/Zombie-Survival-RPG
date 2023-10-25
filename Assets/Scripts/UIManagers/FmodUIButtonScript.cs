using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;
using FMOD.Studio;

public class FMODUIButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("FMOD Event path for click")]
    private string fmodEventPathClick = "event:/Events/ButtonPressed";

    [SerializeField]
    [Tooltip("FMOD Event path for rollover")]
    private string fmodEventPathRollover = "event:/Events/ButtonRollover";

    [SerializeField]
    [Tooltip("FMOD Event path for button exit")]
    private string fmodEventPathExit = "event:/Events/ButtonExit"; // TODO: Add your FMOD Event path for exit

    [SerializeField]
    [Tooltip("Volume control for UI sounds")]
    private float volume = 1f; // Default volume is 1 (max)

    private EventInstance soundEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayFMODSound(fmodEventPathRollover);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayFMODSound(fmodEventPathClick);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayFMODSound(fmodEventPathExit); // TODO: Implement sound for when the pointer exits the button
    }

    private void PlayFMODSound(string eventPath)
    {
        if (!string.IsNullOrEmpty(eventPath))
        {
            soundEvent = RuntimeManager.CreateInstance(eventPath);
            soundEvent.setVolume(volume); // Set the volume for the sound event
            soundEvent.start();
            soundEvent.release();
        }
    }
}