using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AccessibilityOptionsManager : MonoBehaviour
{
    public Dropdown fontSizeDropdown;
    public Toggle colorblindModeToggle;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        fontSizeDropdown.value = (int)settings["FontSize"];
        colorblindModeToggle.isOn = (bool)settings["ColorblindMode"];
    }
}
