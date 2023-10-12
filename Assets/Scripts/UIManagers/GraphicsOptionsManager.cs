using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphicsOptionsManager : Singleton<GraphicsOptionsManager>
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        resolutionDropdown.value = (int)settings["Resolution"];
        qualityDropdown.value = (int)settings["Quality"];
        fullscreenToggle.isOn = (bool)settings["Fullscreen"];
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
}
