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
