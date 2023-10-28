using SimpleSQL;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

public class SimpleSQLManager : SimpleSQL.SimpleSQLManager
{
    // Define your new settings model as a C# class
    [System.Serializable]
    public class SettingsModel
    {
        public string Graphics { get; set; }
        public string Accessibility { get; set; }
        public string Sound { get; set; }
        public string Controls { get; set; }
        public string Gameplay { get; set; }
    }

    // Initialize the database and create the table
    private async void Start()
    {
        // Run database setup on a separate thread
        await Task.Run(() =>
        {
            // Check if the table already exists
            var tableExists = Query<SettingsModel>("SELECT name FROM sqlite_master WHERE type='table' AND name='Settings'").Count > 0;

            // If not, create it
            if (!tableExists)
            {
                Execute("CREATE TABLE Settings (Graphics TEXT, Accessibility TEXT, Sound TEXT, Controls TEXT, Gameplay TEXT)");
            }
        });
    }

    // Method to save settings
    public async Task SaveSettingsAsync(Settings settings)
    {
        string graphicsSettingsJson = JsonUtility.ToJson(settings.graphicsSettings);
        string accessibilitySettingsJson = JsonUtility.ToJson(settings.accessibilitySettings);
        string soundSettingsJson = JsonUtility.ToJson(settings.soundSettings);
        string controlsSettingsJson = JsonUtility.ToJson(settings.controlsSettings);
        string gameplaySettingsJson = JsonUtility.ToJson(settings.gameplaySettings);

        await Task.Run(() =>
        {
            var settingsExist = Query<SettingsModel>("SELECT * FROM Settings LIMIT 1").Count > 0;

            if (settingsExist)
            {
                Execute(
                    "UPDATE Settings SET Graphics = ?, Accessibility = ?, Sound = ?, Controls = ?, Gameplay = ?",
                    graphicsSettingsJson, accessibilitySettingsJson, soundSettingsJson, controlsSettingsJson,
                    gameplaySettingsJson);
            }
            else
            {
                Execute(
                    "INSERT INTO Settings (Graphics, Accessibility, Sound, Controls, Gameplay) VALUES (?, ?, ?, ?, ?)",
                    graphicsSettingsJson, accessibilitySettingsJson, soundSettingsJson, controlsSettingsJson,
                    gameplaySettingsJson);
            }
        });
    }

    // Method to load settings
    public async Task<Settings> LoadSettingsAsync()
    {
        return await Task.Run(() =>
        {
            var result = Query<SettingsModel>("SELECT * FROM Settings LIMIT 1");

            if (result.Count > 0)
            {
                Settings settings = new Settings
                {
                    graphicsSettings = JsonUtility.FromJson<Settings.GraphicsSettings>(result[0].Graphics),
                    accessibilitySettings = JsonUtility.FromJson<Settings.AccessibilitySettings>(result[0].Accessibility),
                    soundSettings = JsonUtility.FromJson<Settings.SoundSettings>(result[0].Sound),
                    controlsSettings = JsonUtility.FromJson<Settings.ControlsSettings>(result[0].Controls),
                    gameplaySettings = JsonUtility.FromJson<Settings.GameplaySettings>(result[0].Gameplay)
                };
                return settings;
            }
            else
            {
                // Return default settings if none found in the database
                return new Settings();
            }
        });
    }

    // Method to update multiple settings
    public async Task UpdateSettingsAsync(Settings settings)
    {
        string graphicsSettingsJson = JsonUtility.ToJson(settings.graphicsSettings);
        string accessibilitySettingsJson = JsonUtility.ToJson(settings.accessibilitySettings);
        string soundSettingsJson = JsonUtility.ToJson(settings.soundSettings);
        string controlsSettingsJson = JsonUtility.ToJson(settings.controlsSettings);
        string gameplaySettingsJson = JsonUtility.ToJson(settings.gameplaySettings);

        await Task.Run(() =>
        {
            Execute(
                "UPDATE Settings SET Graphics = ?, Accessibility = ?, Sound = ?, Controls = ?, Gameplay = ?",
                graphicsSettingsJson, accessibilitySettingsJson, soundSettingsJson, controlsSettingsJson,
                gameplaySettingsJson);
        });
    }

    // Method to delete all settings
    public async Task DeleteSettingsAsync()
    {
        await Task.Run(() =>
        {
            Execute("DELETE FROM Settings");
        });
    }
}
