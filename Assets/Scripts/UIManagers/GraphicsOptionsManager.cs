using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphicsOptionsManager : MonoBehaviour
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
}
