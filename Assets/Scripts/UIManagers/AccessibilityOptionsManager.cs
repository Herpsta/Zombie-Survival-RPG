using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class AccessibilityOptionsManager : MonoBehaviour
{
    [SerializeField] private Settings settings;  // Reference to the Settings class

    [Tooltip("Dropdown for font size selection")]
    public TMP_Dropdown fontSizeDropdown;

    [Tooltip("Toggle for colorblind mode")]
    public Toggle colorblindModeToggle;

    [Tooltip("Dropdown for aspect ratio selection")]
    public TMP_Dropdown aspectRatioDropdown;

    [Tooltip("Toggle for high contrast mode")]
    public Toggle highContrastModeToggle;

    [Tooltip("Toggle for subtitles")]
    public Toggle subtitlesToggle;

    [Tooltip("Toggle for text-to-speech")]
    public Toggle textToSpeechToggle;

    [Tooltip("Toggle for voice commands")]
    public Toggle voiceCommandsToggle; // Added voice commands toggle

    public GameObject accessibilityPanel;

    private void Start()
    {
        // Check if all UI elements and settings are assigned
        if (fontSizeDropdown == null || colorblindModeToggle == null || aspectRatioDropdown == null || highContrastModeToggle == null || subtitlesToggle == null || textToSpeechToggle == null || voiceCommandsToggle == null || settings == null || accessibilityPanel == null)
        {
            Debug.LogError("Not all UI elements or settings are assigned in the inspector");
            return;
        }

        // Add listeners
        fontSizeDropdown.onValueChanged.AddListener(SetFontSize);
        colorblindModeToggle.onValueChanged.AddListener(SetColorblindMode);
        highContrastModeToggle.onValueChanged.AddListener(SetHighContrastMode);
        subtitlesToggle.onValueChanged.AddListener(SetSubtitles);
        textToSpeechToggle.onValueChanged.AddListener(SetTextToSpeech);
        aspectRatioDropdown.onValueChanged.AddListener(SetAspectRatio);
        voiceCommandsToggle.onValueChanged.AddListener(SetVoiceCommands); // Added listener for voice commands

        Load();  // Load settings
    }

    private void OnEnable()
    {
        Load();
    }

    private void OnDisable()
    {
        if (fontSizeDropdown != null)
            fontSizeDropdown.onValueChanged.RemoveListener(SetFontSize);
        if (colorblindModeToggle != null)
            colorblindModeToggle.onValueChanged.RemoveListener(SetColorblindMode);
        if (highContrastModeToggle != null)
            highContrastModeToggle.onValueChanged.RemoveListener(SetHighContrastMode);
        if (subtitlesToggle != null)
            subtitlesToggle.onValueChanged.RemoveListener(SetSubtitles);
        if (textToSpeechToggle != null)
            textToSpeechToggle.onValueChanged.RemoveListener(SetTextToSpeech);
        if (aspectRatioDropdown != null)
            aspectRatioDropdown.onValueChanged.RemoveListener(SetAspectRatio);
        if (voiceCommandsToggle != null)
            voiceCommandsToggle.onValueChanged.RemoveListener(SetVoiceCommands);
    }

    public void ShowPanel()
    {
        accessibilityPanel.SetActive(true);
    }

    public void HidePanel()
    {
        accessibilityPanel.SetActive(false);
    }

    public async Task Save()
    {
        // Save accessibility settings
        AccessibilitySettings accessibilitySettings = new AccessibilitySettings
        {
            FontSize = fontSizeDropdown.value,
            IsColorblindMode = colorblindModeToggle.isOn,
            AspectRatio = aspectRatioDropdown.value,
            IsHighContrastMode = highContrastModeToggle.isOn,
            IsSubtitles = subtitlesToggle.isOn,
            IsTextToSpeech = textToSpeechToggle.isOn,
            IsVoiceCommands = voiceCommandsToggle.isOn
        };

        try
        {
            await settings.SaveToDatabase("Settings", "Accessibility", accessibilitySettings);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save settings: " + e.Message);
        }
    }

    public async Task Load()
    {
        // Load accessibility settings
        AccessibilitySettings accessibilitySettings = null;
        try
        {
            accessibilitySettings = await settings.LoadFromDatabase<AccessibilitySettings>("Settings", "Accessibility");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load settings: " + e.Message);
            return;
        }

        // Update UI
        UpdateUI(accessibilitySettings);
    }
    private void UpdateUI(AccessibilitySettings accessibilitySettings)
    {
        fontSizeDropdown.value = accessibilitySettings.FontSize;
        colorblindModeToggle.isOn = accessibilitySettings.IsColorblindMode;
        aspectRatioDropdown.value = accessibilitySettings.AspectRatio;
        highContrastModeToggle.isOn = accessibilitySettings.IsHighContrastMode;
        subtitlesToggle.isOn = accessibilitySettings.IsSubtitles;
        textToSpeechToggle.isOn = accessibilitySettings.IsTextToSpeech;
        voiceCommandsToggle.isOn = accessibilitySettings.IsVoiceCommands;
    }

    public void SetColorblindMode(bool isColorblind)
    {
        settings.IsColorblindMode = isColorblind;
    }

    public void SetHighContrastMode(bool isHighContrast)
    {
        settings.IsHighContrastMode = isHighContrast;
    }

    public void SetSubtitles(bool isSubtitles)
    {
        settings.IsSubtitles = isSubtitles;
    }

    public void SetTextToSpeech(bool isTextToSpeech)
    {
        settings.IsTextToSpeech = isTextToSpeech;
    }

    public void SetFontSize(int fontSize)
    {
        settings.FontSize = fontSize;
    }

    public void SetAspectRatio(int aspectRatio)
    {
        settings.AspectRatio = aspectRatio;
    }

    public void SetVoiceCommands(bool isVoiceCommands)
    {
        settings.IsVoiceCommands = isVoiceCommands;
    }
}
