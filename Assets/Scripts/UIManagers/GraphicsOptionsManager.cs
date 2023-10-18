using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GraphicsOptionsManager : MonoBehaviour
{
    [Tooltip("Dropdown for resolution selection")]
    public TMP_Dropdown resolutionDropdown;
    [Tooltip("Dropdown for quality selection")]
    public TMP_Dropdown qualityDropdown;
    [Tooltip("Toggle for fullscreen mode")]
    public Toggle fullscreenToggle;
    [Tooltip("Dropdown for aspect ratio selection")]
    public TMP_Dropdown aspectRatioDropdown;
    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
        PopulateQualityDropdown();
        PopulateAspectRatioDropdown();

        resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });
        qualityDropdown.onValueChanged.AddListener(SetQuality);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        aspectRatioDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });

        LoadOptions();
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
        string selectedResolution = resolutionDropdown.options[resolutionDropdown.value].text;
        string[] dimensions = selectedResolution.Split('x');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    private void PopulateResolutionDropdown()
    {
        List<string> options = new List<string>();
        foreach (Resolution res in resolutions)
        {
            string option = res.width + " x " + res.height;
            options.Add(option);
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
    }

    private void PopulateQualityDropdown()
    {
        string[] qualityNames = QualitySettings.names;
        List<string> options = new List<string>(qualityNames);
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(options);
    }

    private void PopulateAspectRatioDropdown()
    {
        List<string> options = new List<string> { "16:9", "16:10", "4:3", "3:2", "5:4", "1:1", "21:9", "32:9" };
        aspectRatioDropdown.ClearOptions();
        aspectRatioDropdown.AddOptions(options);
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("Quality", qualityDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadOptions()
    {
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0);
        qualityDropdown.value = PlayerPrefs.GetInt("Quality", 0);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 0) == 1;
    }
}