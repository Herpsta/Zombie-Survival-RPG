using SimpleSQL;
using UnityEngine;
using System.Collections.Generic;  // For using List

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
    public void SaveSetting(string settingName, string settingValue)
    {
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
    public string LoadSetting(string settingName)
    {
        var result = Query<Settings>("SELECT SettingValue FROM Settings WHERE SettingName = ?", settingName);
        return result.Count > 0 ? result[0].SettingValue : null;
    }
}