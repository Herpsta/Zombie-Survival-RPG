using UnityEngine;
using SimpleSQL;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private SimpleSQLManager dbManager;

    [System.Serializable]
    public class GraphicsSettings
    {
        public int resolutionIndex;
        public bool fullScreen;
    }

    [System.Serializable]
    public class AccessibilitySettings
    {
        public bool subtitles;
        public bool IsColorblindMode;
        public bool IsHighContrastMode;
        public bool IsTextToSpeech;
        public bool IsVoiceCommands;
        public int FontSize;
        public int AspectRatio;
    }

    [System.Serializable]
    public class SoundSettings
    {
        public float masterVolume;
    }

    [System.Serializable]
    public class ControlsSettings
    {
        public KeyCode jumpKey;
    }

    [System.Serializable]
    public class GameplaySettings
    {
        public int difficultyLevel;
    }

    // Create instances of your settings classes here
    public GraphicsSettings graphicsSettings = new GraphicsSettings();
    public AccessibilitySettings accessibilitySettings = new AccessibilitySettings();
    public SoundSettings soundSettings = new SoundSettings();
    public ControlsSettings controlsSettings = new ControlsSettings();
    public GameplaySettings gameplaySettings = new GameplaySettings();

    private async void Start()
    {
        try
        {
            var settings = await Task.Run(() => dbManager.Query<SettingsModel>("SELECT * FROM Settings LIMIT 1"));

            if (settings.Count > 0)
            {
                graphicsSettings = JsonConvert.DeserializeObject<GraphicsSettings>(settings[0].Graphics);
                accessibilitySettings = JsonConvert.DeserializeObject<AccessibilitySettings>(settings[0].Accessibility);
                soundSettings = JsonConvert.DeserializeObject<SoundSettings>(settings[0].Sound);
                controlsSettings = JsonConvert.DeserializeObject<ControlsSettings>(settings[0].Controls);
                gameplaySettings = JsonConvert.DeserializeObject<GameplaySettings>(settings[0].Gameplay);

                // TODO: Apply these settings to your game
            }
            else
            {
                // TODO: Update settings instances with current settings from your game

                SaveSettings();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load settings from the database: " + ex.Message);

            // TODO: Decide what should happen if loading settings fails
        }
    }

    public async void SaveSettings()
    {
        try
        {
            // TODO: Update settings instances with current settings from your game

            string graphicsSettingsJson = JsonConvert.SerializeObject(graphicsSettings);
            string accessibilitySettingsJson = JsonConvert.SerializeObject(accessibilitySettings);
            string soundSettingsJson = JsonConvert.SerializeObject(soundSettings);
            string controlsSettingsJson = JsonConvert.SerializeObject(controlsSettings);
            string gameplaySettingsJson = JsonConvert.SerializeObject(gameplaySettings);

            var settings = await Task.Run(() => dbManager.Query<SettingsModel>("SELECT * FROM Settings LIMIT 1"));

            if (settings.Count > 0)
            {
                await Task.Run(() => dbManager.Execute(
                    "UPDATE Settings SET Graphics = ?, Accessibility = ?, Sound = ?, Controls = ?, Gameplay = ?",
                    graphicsSettingsJson, accessibilitySettingsJson, soundSettingsJson, controlsSettingsJson,
                    gameplaySettingsJson));
            }
            else
            {
                await Task.Run(() => dbManager.Execute(
                    "INSERT INTO Settings (Graphics, Accessibility, Sound, Controls, Gameplay) VALUES (?, ?, ?, ?, ?)",
                    graphicsSettingsJson, accessibilitySettingsJson, soundSettingsJson, controlsSettingsJson,
                    gameplaySettingsJson));
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save settings to the database: " + ex.Message);

            // If saving settings fails, you might want to notify the user or log the error for debugging purposes.
            // For example, you could show a dialog to the user to let them know that the settings could not be saved.
            // You could also try to save the settings again, or revert to the previous settings.

            // Here's an example of how you might handle this:
            try
            {
                // Try to save the settings again
                await SaveSettings();
            }
            catch (System.Exception retryEx)
            {
                Debug.LogError("Failed to save settings to the database on retry: " + retryEx.Message);

                // If saving settings fails again, you might want to revert to the previous settings
                // You'll need to implement this method yourself
                RevertToPreviousSettings();

                // And notify the user
                // You'll need to implement this method yourself
                NotifyUserOfError("Failed to save settings. Your previous settings have been restored.");
            }
        }
    }
}