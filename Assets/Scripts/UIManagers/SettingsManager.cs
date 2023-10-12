using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    private void Awake()
    {
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

    public void SaveOptions(float musicVolume, float sfxVolume, float voiceVolume, int resolution, int quality, bool fullscreen, bool autoSave, int difficulty, int fontSize, bool colorblindMode)
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("VoiceVolume", voiceVolume);
        PlayerPrefs.SetInt("Resolution", resolution);
        PlayerPrefs.SetInt("Quality", quality);
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.SetInt("AutoSave", autoSave ? 1 : 0);
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.SetInt("FontSize", fontSize);
        PlayerPrefs.SetInt("ColorblindMode", colorblindMode ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadOptions(/* Add references to UI elements here to update them based on saved settings */)
    {
        // Load settings from PlayerPrefs and update the UI elements
    }

    public void LoadOptions()
    {
        // Sound
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        voiceVolumeSlider.value = PlayerPrefs.GetFloat("VoiceVolume", 0.75f);

        // Graphics
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0);
        qualityDropdown.value = PlayerPrefs.GetInt("Quality", 0);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        // Gameplay
        autoSaveToggle.isOn = PlayerPrefs.GetInt("AutoSave", 1) == 1;
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty", 0);

        // Accessibility
        fontSizeDropdown.value = PlayerPrefs.GetInt("FontSize", 0);
        colorblindModeToggle.isOn = PlayerPrefs.GetInt("ColorblindMode", 0) == 1;
    }

    using System.Collections.Generic;

public Dictionary<string, object> LoadOptions()
{
    Dictionary<string, object> settings = new Dictionary<string, object>();

    // Sound
    settings["MusicVolume"] = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    settings["SFXVolume"] = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    settings["VoiceVolume"] = PlayerPrefs.GetFloat("VoiceVolume", 0.75f);

    // Graphics
    settings["Resolution"] = PlayerPrefs.GetInt("Resolution", 0);
    settings["Quality"] = PlayerPrefs.GetInt("Quality", 0);
    settings["Fullscreen"] = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

    // Gameplay
    settings["AutoSave"] = PlayerPrefs.GetInt("AutoSave", 1) == 1;
    settings["Difficulty"] = PlayerPrefs.GetInt("Difficulty", 0);

    // Accessibility
    settings["FontSize"] = PlayerPrefs.GetInt("FontSize", 0);
    settings["ColorblindMode"] = PlayerPrefs.GetInt("ColorblindMode", 0) == 1;

    return settings;
}

}
