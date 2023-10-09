using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance;  // Singleton instance

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
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    private Dictionary<float, List<Resolution>> aspectRatioToResolutions;
    public TMPro.TMP_Dropdown aspectRatioDropdown;

    // Gameplay
    public Toggle autoSaveToggle;
    public TMPro.TMP_Dropdown difficultyDropdown;

    // Accessibility
    public TMPro.TMP_Dropdown fontSizeDropdown;
    public Toggle colorblindModeToggle;

    // Text descriptions for each panel
    public TMP_Text soundDescription;
    public TMP_Text graphicsDescription;
    public TMP_Text gameplayDescription;
    public TMP_Text accessibilityDescription;

    private void Awake()
    {
        // Singleton logic
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
        // Load saved settings
        LoadOptions();

        // Hide all panels initially
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);

        // Debug logs to check if any public variables are null
        Debug.Log("Is SoundPanel null? " + (SoundPanel == null));
        Debug.Log("Is GraphicsPanel null? " + (GraphicsPanel == null));
        Debug.Log("Is GameplayPanel null? " + (GameplayPanel == null));
        Debug.Log("Is AccessibilityPanel null? " + (AccessibilityPanel == null));
        Debug.Log("Is audioMixer null? " + (audioMixer == null));
        Debug.Log("Is musicVolumeSlider null? " + (musicVolumeSlider == null));
        Debug.Log("Is sfxVolumeSlider null? " + (sfxVolumeSlider == null));
        Debug.Log("Is voiceVolumeSlider null? " + (voiceVolumeSlider == null));
        Debug.Log("Is qualityDropdown null? " + (qualityDropdown == null));
        Debug.Log("Is fullscreenToggle null? " + (fullscreenToggle == null));
        Debug.Log("Is aspectRatioDropdown null? " + (aspectRatioDropdown == null));
        Debug.Log("Is autoSaveToggle null? " + (autoSaveToggle == null));
        Debug.Log("Is difficultyDropdown null? " + (difficultyDropdown == null));
        Debug.Log("Is fontSizeDropdown null? " + (fontSizeDropdown == null));
        Debug.Log("Is colorblindModeToggle null? " + (colorblindModeToggle == null));

        // Set text descriptions with null checks
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

        // Listen for change events
        if (resolutionDropdown != null)
        {
            resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });
        }
        else
        {
            Debug.LogError("resolutionDropdown is null");
        }
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

    public void ApplySettings()
    {
        SaveOptions();
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
