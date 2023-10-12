using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameplayOptionsManager : MonoBehaviour
{
    public Toggle autoSaveToggle;
    public Dropdown difficultyDropdown;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        autoSaveToggle.isOn = (bool)settings["AutoSave"];
        difficultyDropdown.value = (int)settings["Difficulty"];
    }
}
