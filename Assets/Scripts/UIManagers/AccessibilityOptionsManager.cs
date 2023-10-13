using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AccessibilityOptionsManager : Singleton<AccessibilityOptionsManager>
{
    public TMP_Dropdown fontSizeDropdown;
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
