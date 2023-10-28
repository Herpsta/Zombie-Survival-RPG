using UnityEngine;
using SimpleSQL;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.UI;

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

    public GraphicsSettings graphicsSettings = new GraphicsSettings();
    public AccessibilitySettings accessibilitySettings = new AccessibilitySettings();
    public SoundSettings soundSettings = new SoundSettings();
    public ControlsSettings controlsSettings = new ControlsSettings();
    public GameplaySettings gameplaySettings = new GameplaySettings();

    private int retryCount = 0;

    private async Task Start()
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

                await SaveSettings();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load settings from the database: " + ex.Message + "\n" + ex.StackTrace);

            // TODO: Decide what should happen if loading settings fails
        }
    }

    public async Task SaveSettings()
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
            Debug.LogError("Failed to save settings to the database: " + ex.Message + "\n" + ex.StackTrace);

            if (retryCount < 3)
            {
                retryCount++;
                await Task.Delay(1000);
                await SaveSettings();
            }
            else
            {
                retryCount = 0;  // reset retry count for future save attempts

                RevertToPreviousSettings();
                NotifyUserOfError("Failed to save settings. Your previous settings have been restored.");
            }
        }
    }

    private void RevertToPreviousSettings()
    {
        Debug.LogWarning("Reverting to previous settings. You'll need to implement the logic based on your game's requirements.");
    }

    private void NotifyUserOfError(string message)
    {
        Debug.Log("Displaying error to user: " + message);
        // Assuming you have a dialog system in place
        // DialogManager.ShowError(message);  
    }
}
