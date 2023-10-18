using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AccessibilityOptionsManager : MonoBehaviour
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

    private void Start()
    {
        // Load settings
        int fontSize = PlayerPrefs.GetInt("FontSize", 0);
        bool isColorblind = PlayerPrefs.GetInt("IsColorblind", 0) == 1;
        bool isHighContrast = PlayerPrefs.GetInt("IsHighContrast", 0) == 1;
        bool isSubtitles = PlayerPrefs.GetInt("IsSubtitles", 0) == 1;
        bool isTextToSpeech = PlayerPrefs.GetInt("IsTextToSpeech", 0) == 1;
        int aspectRatio = PlayerPrefs.GetInt("AspectRatio", 0);

        // Set settings
        SetFontSize(fontSize);
        SetColorblindMode(isColorblind);
        SetHighContrastMode(isHighContrast);
        SetSubtitles(isSubtitles);
        SetTextToSpeech(isTextToSpeech);
        SetAspectRatio(aspectRatio);

        // Populate dropdowns
        PopulateFontSizeDropdown();

        // Add listeners
        fontSizeDropdown.onValueChanged.AddListener(delegate { SetFontSize(fontSizeDropdown.value); });
        colorblindModeToggle.onValueChanged.AddListener(SetColorblindMode);
        highContrastModeToggle.onValueChanged.AddListener(SetHighContrastMode);
        subtitlesToggle.onValueChanged.AddListener(SetSubtitles);
        textToSpeechToggle.onValueChanged.AddListener(SetTextToSpeech);
    }

    public void SetColorblindMode(bool isColorblind)
    {
        PlayerPrefs.SetInt("IsColorblind", isColorblind ? 1 : 0);
        colorblindModeToggle.isOn = isColorblind;
    }

    public void SetHighContrastMode(bool isHighContrast)
    {
        PlayerPrefs.SetInt("IsHighContrast", isHighContrast ? 1 : 0);
        highContrastModeToggle.isOn = isHighContrast;
    }

    public void SetSubtitles(bool isSubtitles)
    {
        PlayerPrefs.SetInt("IsSubtitles", isSubtitles ? 1 : 0);
        subtitlesToggle.isOn = isSubtitles;
    }

    public void SetTextToSpeech(bool isTextToSpeech)
    {
        PlayerPrefs.SetInt("IsTextToSpeech", isTextToSpeech ? 1 : 0);
        textToSpeechToggle.isOn = isTextToSpeech;
    }

    public void SetFontSize(int fontSize)
    {
        PlayerPrefs.SetInt("FontSize", fontSize);
        fontSizeDropdown.value = fontSize;
    }

    public void SetAspectRatio(int aspectRatio)
    {
        PlayerPrefs.SetInt("AspectRatio", aspectRatio);
        aspectRatioDropdown.value = aspectRatio;
    }

    private void PopulateFontSizeDropdown()
    {
        List<string> options = new List<string> { "Small", "Medium", "Large" };
        fontSizeDropdown.ClearOptions();
        fontSizeDropdown.AddOptions(options);
    }
}