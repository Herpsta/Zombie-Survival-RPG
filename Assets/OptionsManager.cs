using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    // Panels
    public GameObject SoundPanel;
    public GameObject GraphicsPanel;
    public GameObject GameplayPanel;
    public GameObject AccessibilityPanel;

    // Sound
    public AudioMixer audioMixer; // Reference to the Audio Mixer asset
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider voiceVolumeSlider;

    // Graphics
    private Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    // Gameplay
    public Toggle autoSaveToggle;
    public TMPro.TMP_Dropdown difficultyDropdown;

    // Accessibility
    public TMPro.TMP_Dropdown fontSizeDropdown;
    public Toggle colorblindModeToggle;

    private void Start()
    {
        // Load saved settings
        LoadOptions();

        // Populate the resolutions array
        resolutions = Screen.resolutions;

        // Clear existing options in the dropdown
        resolutionDropdown.ClearOptions();

        // Create a list to hold our options
        List<string> options = new List<string>();

        // Loop through resolutions and add them to the dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        // Add options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Optionally, set the default dropdown value here
    }

    public void SaveOptions()
    {
        // Sound
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.SetFloat("VoiceVolume", voiceVolumeSlider.value);

        // Graphics
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("Quality", qualityDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);

        // Gameplay
        PlayerPrefs.SetInt("AutoSave", autoSaveToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Difficulty", difficultyDropdown.value);

        // Accessibility
        PlayerPrefs.SetInt("FontSize", fontSizeDropdown.value);
        PlayerPrefs.SetInt("ColorblindMode", colorblindModeToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
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

    public void ShowSoundPanel()
    {
        SoundPanel.SetActive(true);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);
    }

    public void ShowGraphicsPanel()
    {
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(true);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);
    }

    public void ShowGameplayPanel()
    {
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        AccessibilityPanel.SetActive(false);
    }

    public void ShowAccessibilityPanel()
    {
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(true);
    }

    public void CloseOptionsAndReturnToMainMenu()
    {
        // Save changes before leaving the Options menu
        SaveOptions();
        // Load the main menu scene
        SceneManager.LoadScene("TitleScreen");
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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void ChangeResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Function for Colorblind Mode
    public void SetColorblindMode(bool isColorblind)
    {
        PlayerPrefs.SetInt("IsColorblind", isColorblind ? 1 : 0);
        // Add logic to apply colorblind settings in the game
    }

    // Function for Font Size
    public void SetFontSize(int fontSize)
    {
        PlayerPrefs.SetInt("FontSize", fontSize);
        // Add logic to change the font size in the game
    }

    // Function for Difficulty
    public void SetDifficulty(int difficultyLevel)
    {
        PlayerPrefs.SetInt("DifficultyLevel", difficultyLevel);
        // Add logic to set the difficulty level in the game
    }

    // Function for Auto-Save
    public void SetAutoSave(bool autoSave)
    {
        PlayerPrefs.SetInt("AutoSave", autoSave ? 1 : 0);
        // Add logic to enable/disable auto-save in the game
    }
}
