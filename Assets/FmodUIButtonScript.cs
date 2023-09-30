using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using FMODUnity;

public class FMODUIButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private string fmodEventPathClick; // FMOD Event path for click, e.g., "event:/ButtonClick"

    [SerializeField]
    private string fmodEventPathRollover; // FMOD Event path for rollover, e.g., "event:/ButtonRollover"

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play rollover sound
        PlayFMODSound(fmodEventPathRollover);
    }

    public void OnPointerClick(PointerEventData eventData)
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
