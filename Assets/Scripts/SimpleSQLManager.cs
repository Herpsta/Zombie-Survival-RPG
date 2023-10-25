using SimpleSQL;
using UnityEngine;
using System.Collections.Generic;  // For using List
using System.Linq; // For using LINQ
using System; // For using Convert
using System.Text; // For using Encoding

public class SimpleSQLManager : SimpleSQL.SimpleSQLManager
{
    // Define your table as a C# class
    [System.Serializable]
    public class Settings
    {
        public string SettingName;
        public string SettingValue;
    }

    // Initialize the database and create the table
    void Start()
    {
        // Check if the table already exists
        var tableExists = Query<Settings>("SELECT name FROM sqlite_master WHERE type='table' AND name='Settings'").Count > 0;

        // If not, create it
        if (!tableExists)
        {
            Execute("CREATE TABLE Settings (SettingName TEXT PRIMARY KEY, SettingValue TEXT)");
        }
    }

    // Method to save a setting
    public void SaveSetting(string settingName, string settingValue, bool isSensitive = false)
    {
        // If the setting is sensitive, encrypt it
        if (isSensitive)
        {
            settingValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(settingValue));
        }

        // Check if the setting already exists
        var settingExists = Query<Settings>("SELECT * FROM Settings WHERE SettingName = ?", settingName).Count > 0;

        // If it does, update it. Otherwise, insert a new row
        if (settingExists)
        {
            Execute("UPDATE Settings SET SettingValue = ? WHERE SettingName = ?", settingValue, settingName);
        }
        else
        {
            Execute("INSERT INTO Settings (SettingName, SettingValue) VALUES (?, ?)", settingName, settingValue);
        }
    }

    // Method to load a setting
    public string LoadSetting(string settingName, bool isSensitive = false)
    {
        var result = Query<Settings>("SELECT SettingValue FROM Settings WHERE SettingName = ?", settingName);
        if (result.Count > 0)
        {
            string settingValue = result[0].SettingValue;

            // If the setting is sensitive, decrypt it
            if (isSensitive)
            {
                settingValue = Encoding.UTF8.GetString(Convert.FromBase64String(settingValue));
            }

            return settingValue;
        }
        else
        {
            return null;
        }
    }

    // TODO: Add methods for deleting and updating multiple settings at once.
    public void DeleteSettings(List<string> settingNames)
    {
        foreach (var settingName in settingNames)
        {
            Execute("DELETE FROM Settings WHERE SettingName = ?", settingName);
        }
    }

    public void UpdateSettings(Dictionary<string, string> settings, bool isSensitive = false)
    {
        foreach (var setting in settings)
        {
            SaveSetting(setting.Key, setting.Value, isSensitive);
        }
    }
}