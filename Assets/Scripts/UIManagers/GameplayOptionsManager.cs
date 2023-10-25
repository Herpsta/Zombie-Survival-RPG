using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class GameplayOptionsManager : MonoBehaviour
{
    [Tooltip("Toggle for auto-save option")]
    public Toggle autoSaveToggle;

    [Tooltip("Dropdown for difficulty selection")]
    public TMP_Dropdown difficultyDropdown;

    [Tooltip("Panel for gameplay options")]
    public GameObject gameplayPanel;

    private void Start()
    {
        // Load saved settings
        Load();

        // Add listeners to UI elements
        autoSaveToggle.onValueChanged.AddListener(SetAutoSave);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);

        // Populate the difficulty dropdown
        PopulateDifficultyDropdown();
    }

    public void ShowPanel()
    {
        gameplayPanel.SetActive(true);
    }

    public void HidePanel()
    {
        gameplayPanel.SetActive(false);
    }

    public void Save()
    {
        // Save the state of the autoSaveToggle
        PlayerPrefs.SetInt("AutoSave", autoSaveToggle.isOn ? 1 : 0);

        // Save the value of the difficultyDropdown
        PlayerPrefs.SetInt("Difficulty", difficultyDropdown.value);

        // Commit changes to disk
        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Load saved auto-save state and set the toggle
        autoSaveToggle.isOn = PlayerPrefs.GetInt("AutoSave", 0) == 1; // Default to off (0) if not found

        // Load saved difficulty level and set the dropdown value
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty", 0); // Default to the first option (0) if not found
    }

    // Function for Difficulty
    public void SetDifficulty(int difficultyLevel)
    {
        PlayerPrefs.SetInt("Difficulty", difficultyLevel);
        // TODO: Add logic to set the difficulty level in the game
    }

    // Function for Auto-Save
    public void SetAutoSave(bool autoSave)
    {
        PlayerPrefs.SetInt("AutoSave", autoSave ? 1 : 0);
        // TODO: Add logic to enable/disable auto-save in the game
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
}