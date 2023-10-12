using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OptionsManager : MonoBehaviour
{                       
    // To hide the 4 buttons when any panel is active
    public GameObject buttonContainer;
    public GameObject applyButton;

    // Panels
    public GameObject SoundPanel;
    public GameObject GraphicsPanel;
    public GameObject GameplayPanel;
    public GameObject AccessibilityPanel;

    // Panel Titles
    public TMP_Text soundPanelTitle;
    public TMP_Text graphicsPanelTitle;
    public TMP_Text gameplayPanelTitle;
    public TMP_Text accessibilityPanelTitle;

    // Text Descriptions
    public TMP_Text soundDescription;
    public TMP_Text graphicsDescription;
    public TMP_Text gameplayDescription;
    public TMP_Text accessibilityDescription;

    // Flags for lazy initialization
    private bool isResolutionDropdownPopulated = false;
    private bool isQualityDropdownPopulated = false;
    private bool isAspectRatioDropdownPopulated = false;
    private bool isDifficultyDropdownPopulated = false;
    private bool isFontSizeDropdownPopulated = false;

    private void Start()
    {
        // Load saved options
        SettingsManager.Instance.LoadOptions();

        // Initialize panels as inactive
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);

        // Add listeners for UI elements
        AddDropdownListener(resolutionDropdown, delegate { ChangeResolution(); }, "resolutionDropdown is null");
        AddDropdownListener(qualityDropdown, delegate { SetQuality(qualityDropdown.value); }, "qualityDropdown is null");
        AddDropdownListener(aspectRatioDropdown, delegate { ChangeResolution(); }, "aspectRatioDropdown is null");
        AddDropdownListener(difficultyDropdown, delegate { SetDifficulty(difficultyDropdown.value); }, "difficultyDropdown is null");
        AddDropdownListener(fontSizeDropdown, delegate { SetFontSize(fontSizeDropdown.value); }, "fontSizeDropdown is null");

        // New: Add listeners for sliders
        AddSliderListener(musicVolumeSlider, SetMusicVolume, "musicVolumeSlider is null");
        AddSliderListener(sfxVolumeSlider, SetSFXVolume, "sfxVolumeSlider is null");
        AddSliderListener(voiceVolumeSlider, SetVoiceVolume, "voiceVolumeSlider is null");

        // New: Add listeners for toggles
        AddToggleListener(fullscreenToggle, SetFullscreen, "fullscreenToggle is null");
        AddToggleListener(autoSaveToggle, SetAutoSave, "autoSaveToggle is null");
        AddToggleListener(colorblindModeToggle, SetColorblindMode, "colorblindModeToggle is null");

        // Set text descriptions
        if (soundDescription != null)
        {
            soundDescription.text = "Adjust the volume levels for music, SFX, and voice.";
        }
        else
        {
            Debug.LogError("soundDescription is null");
        }

        if (graphicsDescription != null)
        {
            graphicsDescription.text = "Change the resolution and quality settings.";
        }
        else
        {
            Debug.LogError("graphicsDescription is null");
        }

        if (gameplayDescription != null)
        {
            gameplayDescription.text = "Modify gameplay settings like difficulty.";
        }
        else
        {
            Debug.LogError("gameplayDescription is null");
        }

        if (accessibilityDescription != null)
        {
            accessibilityDescription.text = "Customize settings for better accessibility.";
        }
        else
        {
            Debug.LogError("accessibilityDescription is null");
        }

        AddDropdownListener(resolutionDropdown, delegate { ChangeResolution(); }, "resolutionDropdown is null");
        AddDropdownListener(qualityDropdown, delegate { SetQuality(qualityDropdown.value); }, "qualityDropdown is null");
        AddDropdownListener(aspectRatioDropdown, delegate { ChangeResolution(); }, "aspectRatioDropdown is null");
        AddDropdownListener(difficultyDropdown, delegate { SetDifficulty(difficultyDropdown.value); }, "difficultyDropdown is null");
        AddDropdownListener(fontSizeDropdown, delegate { SetFontSize(fontSizeDropdown.value); }, "fontSizeDropdown is null");
    }

    // New: Generic function to add dropdown listeners
    private void AddDropdownListener(TMP_Dropdown dropdown, UnityAction<int> action, string errorMessage)
    {
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    // New: Generic function to add slider listeners
    private void AddSliderListener(Slider slider, UnityAction<float> action, string errorMessage)
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    // New: Generic function to add toggle listeners
    private void AddToggleListener(Toggle toggle, UnityAction<bool> action, string errorMessage)
    {
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    public void SaveAllOptions()
    {
        SoundOptionsManager.Instance.SaveOptions();
        GraphicsOptionsManager.Instance.SaveOptions();
        GameplayOptionsManager.Instance.SaveOptions();
        AccessibilityOptionsManager.Instance.SaveOptions();

        // Save these settings using SettingsManager
        SettingsManager.Instance.SaveOptions(musicVolume, sfxVolume, voiceVolume, resolution, quality, fullscreen, autoSave, difficulty, fontSize, colorblindMode);
    }
}