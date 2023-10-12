using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;  // Singleton instance
                                            
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

    // Sound
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider voiceVolumeSlider;

    // Graphics
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public TMP_Dropdown aspectRatioDropdown;
    private Resolution[] resolutions;

    // Gameplay
    public Toggle autoSaveToggle;
    public TMP_Dropdown difficultyDropdown;

    // Accessibility
    public TMP_Dropdown fontSizeDropdown;
    public Toggle colorblindModeToggle;

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

    public void ChangeResolution()
    {
        float selectedAspectRatio = float.Parse(aspectRatioDropdown.options[aspectRatioDropdown.value].text);
        string selectedResolution = resolutionDropdown.options[resolutionDropdown.value].text;
        string[] dimensions = selectedResolution.Split('x');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    private void Start()
    {
        // Load saved options
        SettingsManager.Instance.LoadOptions();

        // Initialize panels as inactive
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);

        // Populate the resolution dropdown
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        foreach (Resolution res in resolutions)
        {
            string option = res.width + " x " + res.height;
            options.Add(option);
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);

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



    // Show Sound Panel and hide others
    public void ShowSoundPanel()
    {
        buttonContainer.SetActive(false);
        applyButton.SetActive(true); // Show the Apply button

        SoundPanel.SetActive(true);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);
    }

    // Show Graphics Panel and hide others
    public void ShowGraphicsPanel()
    {
        buttonContainer.SetActive(false);
        applyButton.SetActive(true); // Show the Apply button

        // Lazy initialization for dropdowns
        if (!isResolutionDropdownPopulated)
        {
            PopulateResolutionDropdown();
            isResolutionDropdownPopulated = true;
        }
        if (!isQualityDropdownPopulated)
        {
            PopulateQualityDropdown();
            isQualityDropdownPopulated = true;
        }
        if (!isAspectRatioDropdownPopulated)
        {
            PopulateAspectRatioDropdown();
            isAspectRatioDropdownPopulated = true;
        }

        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(true);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);
    }

    // Show Gameplay Panel and hide others
    public void ShowGameplayPanel()
    {
        buttonContainer.SetActive(false);
        applyButton.SetActive(true); // Show the Apply button

        // Lazy initialization for dropdowns
        if (!isDifficultyDropdownPopulated)
        {
            PopulateDifficultyDropdown();
            isDifficultyDropdownPopulated = true;
        }

        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        AccessibilityPanel.SetActive(false);
    }

    // Show Accessibility Panel and hide others
    public void ShowAccessibilityPanel()
    {
        buttonContainer.SetActive(false);
        applyButton.SetActive(true); // Show the Apply button

        // Lazy initialization for dropdowns
        if (!isFontSizeDropdownPopulated)
        {
            PopulateFontSizeDropdown();
            isFontSizeDropdownPopulated = true;
        }

        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(true);
    }

    public void SaveAllOptions()
    {
        // Collect settings from each panel-specific manager
        float musicVolume = SoundOptionsManager.Instance.GetMusicVolume();
        float sfxVolume = SoundOptionsManager.Instance.GetSFXVolume();
        float voiceVolume = SoundOptionsManager.Instance.GetVoiceVolume();

        int resolution = GraphicsOptionsManager.Instance.GetResolution();
        int quality = GraphicsOptionsManager.Instance.GetQuality();
        bool fullscreen = GraphicsOptionsManager.Instance.GetFullscreen();

        bool autoSave = GameplayOptionsManager.Instance.GetAutoSave();
        int difficulty = GameplayOptionsManager.Instance.GetDifficulty();

        int fontSize = AccessibilityOptionsManager.Instance.GetFontSize();
        bool colorblindMode = AccessibilityOptionsManager.Instance.GetColorblindMode();

        // Save these settings using SettingsManager
        SettingsManager.Instance.SaveOptions(musicVolume, sfxVolume, voiceVolume, resolution, quality, fullscreen, autoSave, difficulty, fontSize, colorblindMode);
    }

    // Populate Resolution Dropdown
    private void PopulateResolutionDropdown()
    {
        // Get available screen resolutions
        Resolution[] resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        // Loop through and add resolutions to the dropdown
        foreach (Resolution res in resolutions)
        {
            string option = res.width + " x " + res.height;
            options.Add(option);
        }

        // Clear and add new options to the dropdown
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
    }

    // Populate Quality Dropdown
    private void PopulateQualityDropdown()
    {
        // Get quality settings names
        string[] qualityNames = QualitySettings.names;
        List<string> options = new List<string>(qualityNames);

        // Clear and add new options to the dropdown
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(options);
    }

    // Populate Aspect Ratio Dropdown
    private void PopulateAspectRatioDropdown()
    {
        // Define common aspect ratios
        List<string> options = new List<string> { "16:9", "16:10", "4:3", "3:2" };

        // Clear and add new options to the dropdown
        aspectRatioDropdown.ClearOptions();
        aspectRatioDropdown.AddOptions(options);
    }

    // Populate Difficulty Dropdown
    private void PopulateDifficultyDropdown()
    {
        // Define difficulty levels
        List<string> options = new List<string> { "Easy", "Medium", "Hard", "Expert" };

        // Clear and add new options to the dropdown
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(options);
    }

    // Populate Font Size Dropdown
    private void PopulateFontSizeDropdown()
    {
        // Define font sizes
        List<string> options = new List<string> { "Small", "Medium", "Large" };

        // Clear and add new options to the dropdown
        fontSizeDropdown.ClearOptions();
        fontSizeDropdown.AddOptions(options);
    }

}
