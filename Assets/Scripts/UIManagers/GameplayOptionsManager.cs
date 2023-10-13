using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class GameplayOptionsManager : Singleton<GameplayOptionsManager>
{
    public Toggle autoSaveToggle;
    public TMP_Dropdown difficultyDropdown;

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

    // Populate Difficulty Dropdown
    private void PopulateDifficultyDropdown()
    {
        // Define difficulty levels
        List<string> options = new List<string> { "Easy", "Medium", "Hard", "Expert" };

        // Clear and add new options to the dropdown
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(options);
    }

    internal void SaveOptions()
    {
        
    }
}