using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccessibilityOptionsManager : Singleton<GraphicsOptionsManager>
{
    public Dropdown fontSizeDropdown;
    public Toggle colorblindModeToggle;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        fontSizeDropdown.value = (int)settings["FontSize"];
        colorblindModeToggle.isOn = (bool)settings["ColorblindMode"];
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
}
