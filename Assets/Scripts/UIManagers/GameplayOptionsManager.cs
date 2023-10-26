using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameplayOptionsManager : MonoBehaviour
{
    [Tooltip("Toggle for auto-save option")]
    public Toggle autoSaveToggle;

    [Tooltip("Dropdown for difficulty selection")]
    public TMP_Dropdown difficultyDropdown;

    [Tooltip("Slider for camera sensitivity")]
    public Slider cameraSensitivitySlider;

    [Tooltip("Panel for gameplay options")]
    public GameObject gameplayPanel;

    [SerializeField] private Settings settings;  // Reference to the Settings class

    private void Start()
    {
        // Check if UI elements are assigned
        if (autoSaveToggle == null || difficultyDropdown == null || cameraSensitivitySlider == null)
        {
            Debug.LogError("All UI elements must be assigned in the inspector.");
            return;
        }

        // Load saved settings
        Load();

        // Add listeners to UI elements
        autoSaveToggle.onValueChanged.AddListener(SetAutoSave);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);
        cameraSensitivitySlider.onValueChanged.AddListener(SetCameraSensitivity);

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

    public async Task Save()
    {
        try
        {
            // Save gameplay settings
            GameplaySettings gameplaySettings = new GameplaySettings
            {
                AutoSave = autoSaveToggle.isOn,
                Difficulty = difficultyDropdown.value,
                CameraSensitivity = cameraSensitivitySlider.value
            };
            await settings.SaveToDatabase("Settings", "Gameplay", gameplaySettings);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save settings: " + e.Message);
        }

        // TODO: Save other settings
    }

    public async Task Load()
    {
        try
        {
            // Load gameplay settings
            GameplaySettings gameplaySettings = await settings.LoadFromDatabase<GameplaySettings>("Settings", "Gameplay");

            // Update UI
            UpdateUI(gameplaySettings);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load settings: " + e.Message);
        }

        // TODO: Load other settings and update UI
    }

    private void UpdateUI(GameplaySettings gameplaySettings)
    {
        // Ensure we're on the main thread
        if (!UnityMainThreadDispatcher.Instance().IsMainThread())
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() => UpdateUI(gameplaySettings));
            return;
        }

        autoSaveToggle.isOn = gameplaySettings.AutoSave;
        difficultyDropdown.value = gameplaySettings.Difficulty;
        cameraSensitivitySlider.value = gameplaySettings.CameraSensitivity;
    }

    public void SetDifficulty(int difficultyLevel)
    {
        // TODO: Add logic to set the difficulty level in the game
    }

    public void SetAutoSave(bool autoSave)
    {
        // TODO: Add logic to enable/disable auto-save in the game
    }

    public void SetCameraSensitivity(float sensitivity)
    {
        // TODO: Add logic to adjust camera sensitivity in the game
    }

    private void PopulateDifficultyDropdown()
    {
        // Define difficulty levels
        List<string> options = new List<string> { "Easy", "Medium", "Hard", "Expert" };

        // Clear and add new options to the dropdown
        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(options);
    }
}