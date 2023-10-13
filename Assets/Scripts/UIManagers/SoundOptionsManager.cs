using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;

public class SoundOptionsManager : Singleton<SoundOptionsManager>
{
    public AudioMixer audioMixer;
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

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetVoiceVolume(float volume)
    {
        audioMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Voice", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    public void SaveOptions()
    {
        float musicVolume = SoundOptionsManager.Instance.GetMusicVolume();
        float sfxVolume = SoundOptionsManager.Instance.GetSFXVolume();
        float voiceVolume = SoundOptionsManager.Instance.GetVoiceVolume();
    }

    private float GetVoiceVolume()
    {
        return voiceVolumeSlider.value;
    }

    private float GetMusicVolume()
    {
        return musicVolumeSlider.value;
    }

    private float GetSFXVolume()
    {
        return sfxVolumeSlider.value;
    }
}