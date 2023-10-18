using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;

public class SoundOptionsManager : MonoBehaviour
{
    [Tooltip("Audio mixer for controlling volumes")]
    public AudioMixer audioMixer;

    [Tooltip("Slider for controlling music volume")]
    public Slider musicVolumeSlider;

    [Tooltip("Slider for controlling SFX volume")]
    public Slider sfxVolumeSlider;

    [Tooltip("Slider for controlling voice volume")]
    public Slider voiceVolumeSlider;

    void Start()
    {
        // Load settings
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        musicVolumeSlider.value = (float)settings["MusicVolume"];
        sfxVolumeSlider.value = (float)settings["SFXVolume"];
        voiceVolumeSlider.value = (float)settings["VoiceVolume"];

        // Add listeners for sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        voiceVolumeSlider.onValueChanged.AddListener(SetVoiceVolume);
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
        PlayerPrefs.SetFloat("MusicVolume", GetMusicVolume());
        PlayerPrefs.SetFloat("SFXVolume", GetSFXVolume());
        PlayerPrefs.SetFloat("VoiceVolume", GetVoiceVolume());
        PlayerPrefs.Save();
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