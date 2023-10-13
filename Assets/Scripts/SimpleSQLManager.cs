using SimpleSQL;
using UnityEngine;
using System.Linq;  // For using FirstOrDefault()

public class SimpleSQLManager : SimpleSQL.SimpleSQLManager
{
    // Define your table as a C# class
    [System.Serializable]
    public class Settings
    {
        public string SettingName;
        public string SettingValue;
    }

    // Wrapper class for setting value
    [System.Serializable]
    public class SettingValueWrapper
    {
        public string SettingValue;
    }

    // Initialize the database and create the table
    void Start()
    {
        Execute("CREATE TABLE IF NOT EXISTS Settings (SettingName TEXT PRIMARY KEY, SettingValue TEXT)");
    }

    // Method to save a setting
    public void SaveSetting(string settingName, string settingValue)
    {
        string query = "REPLACE INTO Settings (SettingName, SettingValue) VALUES (?, ?)";
        Execute(query, settingName, settingValue);
    }

    // Method to load a setting
    public string LoadSetting(string settingName)
    {
        string query = "SELECT SettingValue FROM Settings WHERE SettingName = ?";
        var result = Query<SettingValueWrapper>(query, settingName).FirstOrDefault();
        return result != null ? result.SettingValue : null;
    }
}
