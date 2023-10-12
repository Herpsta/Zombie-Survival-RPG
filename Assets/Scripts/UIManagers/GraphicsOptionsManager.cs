using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GraphicsOptionsManager : Singleton<GraphicsOptionsManager>
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public TMP_Dropdown aspectRatioDropdown;
    private Resolution[] resolutions;

    void Start()
    {
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

        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        resolutionDropdown.value = (int)settings["Resolution"];
        qualityDropdown.value = (int)settings["Quality"];
        fullscreenToggle.isOn = (bool)settings["Fullscreen"];
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
        float selectedAspectRatio = float.Parse(aspectRatioDropdown.options[aspectRatioDropdown.value].text);
        string selectedResolution = resolutionDropdown.options[resolutionDropdown.value].text;
        string[] dimensions = selectedResolution.Split('x');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        Screen.SetResolution(width, height, Screen.fullScreen);
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

    public void SaveOptions()
    {
        int resolution = GraphicsOptionsManager.Instance.GetResolution();
        int quality = GraphicsOptionsManager.Instance.GetQuality();
        bool fullscreen = GraphicsOptionsManager.Instance.GetFullscreen();
    }
}