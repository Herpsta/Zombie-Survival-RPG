using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

public class FMODUIButton : MonoBehaviour
{
    [SerializeField]
    private string fmodEventPathClick = "event:/Events/ButtonPressed"; // FMOD Event path for click

    [SerializeField]
    private string fmodEventPathRollover = "event:/Events/ButtonRollover"; // FMOD Event path for rollover

    private PointerEventData latestEventData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        latestEventData = eventData;
        OnPointerEnterWrapper();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        latestEventData = eventData;
        OnPointerClickWrapper();
    }

    public void OnPointerEnterWrapper()
    {
        // Play rollover sound
        PlayFMODSound(fmodEventPathRollover);
    }

    public void OnPointerClickWrapper()
    {
        // Play click sound
        PlayFMODSound(fmodEventPathClick);
    }

    private void PlayFMODSound(string eventPath)
    {
        if (!string.IsNullOrEmpty(eventPath))
        {
            RuntimeManager.PlayOneShot(eventPath);
        }
    }
}
