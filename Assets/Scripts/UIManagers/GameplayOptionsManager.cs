using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameplayOptionsManager : Singleton<GameplayOptionsManager>
{
    public Toggle autoSaveToggle;
    public Dropdown difficultyDropdown;

    void Start()
    {
        Dictionary<string, object> settings = SettingsManager.Instance.LoadOptions();
        autoSaveToggle.isOn = (bool)settings["AutoSave"];
        difficultyDropdown.value = (int)settings["Difficulty"];
    }

    // Function for Difficulty
    public void SetDifficulty(int difficultyLevel)
    {
        PlayerPrefs.SetInt("DifficultyLevel", difficultyLevel);
        // Add logic to set the difficulty level in the game
    }

    // Function for Auto-Save
    public void SetAutoSave(bool autoSave)
    {
        PlayerPrefs.SetInt("AutoSave", autoSave ? 1 : 0);
        // Add logic to enable/disable auto-save in the game
    }
}
