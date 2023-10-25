using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleSQL;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private SimpleSQLManager dbManager;

    // Placeholder classes for each type of settings
    [System.Serializable]
    public class GraphicsSettings
    {
        public int resolutionIndex;
        public bool fullScreen;
        // Add more graphics settings here
    }

    [System.Serializable]
    public class AccessibilitySettings
    {
        public bool subtitles;
        // Add more accessibility settings here
    }

    [System.Serializable]
    public class SoundSettings
    {
        public float masterVolume;
        // Add more sound settings here
    }

    [System.Serializable]
    public class ControlsSettings
    {
        public KeyCode jumpKey;
        // Add more controls settings here
    }

    [System.Serializable]
    public class GameplaySettings
    {
        public int difficultyLevel;
        // Add more gameplay settings here
    }

    private async void Start()
    {
        try
        {
            // Load settings from the database
            var settings = await Task.Run(() => dbManager.Query<SettingsModel>("SELECT * FROM Settings LIMIT 1"));

            if (settings.Count > 0)
            {
                // Deserialize settings from JSON
                GraphicsSettings graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(settings[0].Graphics);
                // Apply these settings to your game
                // TODO: Implement this

                // Similarly, deserialize and apply other settings
                // TODO: Implement this
            }
            else
            {
                // Initialize settings with default values
                SaveSettings();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load settings from the database: " + ex.Message);
        }
    }

    public async void SaveSettings()
    {
        try
        {
            // Serialize settings to JSON
            string graphicsSettings = JsonConvert.SerializeObject(new GraphicsSettings
            {
                resolutionIndex = 0,
                fullScreen = true
            });

            string accessibilitySettings = JsonConvert.SerializeObject(new AccessibilitySettings
            {
                subtitles = true
            });

            string soundSettings = JsonConvert.SerializeObject(new SoundSettings
            {
                masterVolume = 1.0f
            });

            string controlsSettings = JsonConvert.SerializeObject(new ControlsSettings
            {
                jumpKey = KeyCode.Space
            });

            string gameplaySettings = JsonConvert.SerializeObject(new GameplaySettings
            {
                difficultyLevel = 1
            });

            // Save settings to the database
            await Task.Run(() => dbManager.Execute("UPDATE Settings SET Graphics = ?, Accessibility = ?, Sound = ?, Controls = ?, Gameplay = ?",
                graphicsSettings, accessibilitySettings, soundSettings, controlsSettings, gameplaySettings));

            // Update the UI to reflect the saved settings
            UpdateUI();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save settings to the database: " + ex.Message);
        }
    }

    private void UpdateUI()
    {
        // Update your UI elements here based on the current settings
        // TODO: Implement this
    }
}
