using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SoundOptionsManager : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider voiceVolumeSlider;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        musicVolumeSlider.value = (float)settings["MusicVolume"];
        sfxVolumeSlider.value = (float)settings["SFXVolume"];
        voiceVolumeSlider.value = (float)settings["VoiceVolume"];
    }
}
