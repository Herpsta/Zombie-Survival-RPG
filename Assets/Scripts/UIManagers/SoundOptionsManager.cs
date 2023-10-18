using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;

public class SoundOptionsManager : MonoBehaviour, IPanelManager
{
    [Tooltip("Audio mixer for controlling volumes")]
    public AudioMixer audioMixer;

    [Tooltip("Slider for controlling music volume")]
    public Slider musicVolumeSlider;

    [Tooltip("Slider for controlling SFX volume")]
    public Slider sfxVolumeSlider;

    [Tooltip("Slider for controlling voice volume")]
    public Slider voiceVolumeSlider;

    public GameObject soundPanel;
    public static SoundOptionsManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        OptionsManager.Instance.RegisterPanel(this);

        Load();  // Add this line

        // Add listeners for sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        voiceVolumeSlider.onValueChanged.AddListener(SetVoiceVolume);
    }

    public void ShowPanel()
    {
        soundPanel.SetActive(true);
    }

    public void HidePanel()
    {
        soundPanel.SetActive(false);
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

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", GetMusicVolume());
        PlayerPrefs.SetFloat("SFXVolume", GetSFXVolume());
        PlayerPrefs.SetFloat("VoiceVolume", GetVoiceVolume());
        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Load saved music volume and set the slider value
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // Default to 0.5 if not found

        // Load saved SFX volume and set the slider value
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f); // Default to 0.5 if not found

        // Load saved voice volume and set the slider value
        voiceVolumeSlider.value = PlayerPrefs.GetFloat("VoiceVolume", 0.5f); // Default to 0.5 if not found
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