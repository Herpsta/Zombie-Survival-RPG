using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AccessibilityOptionsManager : MonoBehaviour, IPanelManager
{
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

    public GameObject accessibilityPanel;

    private void Start()
    {
        OptionsManager.Instance.RegisterPanel(this);
        Load();  // Load settings

        // Populate dropdowns
        PopulateFontSizeDropdown();
        PopulateAspectRatioDropdown();

        // Add listeners
        fontSizeDropdown.onValueChanged.AddListener(SetFontSize);
        colorblindModeToggle.onValueChanged.AddListener(SetColorblindMode);
        highContrastModeToggle.onValueChanged.AddListener(SetHighContrastMode);
        subtitlesToggle.onValueChanged.AddListener(SetSubtitles);
        textToSpeechToggle.onValueChanged.AddListener(SetTextToSpeech);
        aspectRatioDropdown.onValueChanged.AddListener(SetAspectRatio);
    }

    public void ShowPanel()
    {
        accessibilityPanel.SetActive(true);
    }

    public void HidePanel()
    {
        accessibilityPanel.SetActive(false);
    }

    public void Save()
    {
        // Save settings to PlayerPrefs
        PlayerPrefs.SetInt("FontSize", fontSizeDropdown.value);
        PlayerPrefs.SetInt("IsColorblind", colorblindModeToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("IsHighContrast", highContrastModeToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("IsSubtitles", subtitlesToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("IsTextToSpeech", textToSpeechToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("AspectRatio", aspectRatioDropdown.value);

        // Commit changes to disk
        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Load settings from PlayerPrefs
        fontSizeDropdown.value = PlayerPrefs.GetInt("FontSize", 0);
        colorblindModeToggle.isOn = PlayerPrefs.GetInt("IsColorblind", 0) == 1;
        highContrastModeToggle.isOn = PlayerPrefs.GetInt("IsHighContrast", 0) == 1;
        subtitlesToggle.isOn = PlayerPrefs.GetInt("IsSubtitles", 0) == 1;
        textToSpeechToggle.isOn = PlayerPrefs.GetInt("IsTextToSpeech", 0) == 1;
        aspectRatioDropdown.value = PlayerPrefs.GetInt("AspectRatio", 0);
    }

    public void SetColorblindMode(bool isColorblind)
    {
        PlayerPrefs.SetInt("IsColorblind", isColorblind ? 1 : 0);
    }

    public void SetHighContrastMode(bool isHighContrast)
    {
        PlayerPrefs.SetInt("IsHighContrast", isHighContrast ? 1 : 0);
    }

    public void SetSubtitles(bool isSubtitles)
    {
        PlayerPrefs.SetInt("IsSubtitles", isSubtitles ? 1 : 0);
    }

    public void SetTextToSpeech(bool isTextToSpeech)
    {
        PlayerPrefs.SetInt("IsTextToSpeech", isTextToSpeech ? 1 : 0);
    }

    public void SetFontSize(int fontSize)
    {
        PlayerPrefs.SetInt("FontSize", fontSize);
    }

    public void SetAspectRatio(int aspectRatio)
    {
        PlayerPrefs.SetInt("AspectRatio", aspectRatio);
    }

    private void PopulateFontSizeDropdown()
    {
        List<string> options = new List<string> { "Small", "Medium", "Large" };
        fontSizeDropdown.ClearOptions();
        fontSizeDropdown.AddOptions(options);
    }

    private void PopulateAspectRatioDropdown()
    {
        List<string> options = new List<string> { "4:3", "16:9", "21:9" };
        aspectRatioDropdown.ClearOptions();
        aspectRatioDropdown.AddOptions(options);
    }
}