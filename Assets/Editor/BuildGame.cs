using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildGame : EditorWindow
{
    string releaseType = "Build";

    [MenuItem("Build/Build All")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BuildGame));
    }

    void OnGUI()
    {
        GUILayout.Label("Select the release type", EditorStyles.boldLabel);
        releaseType = EditorGUILayout.TextField("Release Type", releaseType);

        if (GUILayout.Button("Build"))
        {
            BuildAll();
        }
    }

    void BuildAll()
    {
        // Read the current version from a file
        string versionPath = "Assets/version.txt"; // Replace with the actual path
        string currentVersion = File.ReadAllText(versionPath);
        string[] versionParts = currentVersion.Split('.');
        int major = int.Parse(versionParts[0]);
        int minor = int.Parse(versionParts[1]);
        int patch = int.Parse(versionParts[2]);
        int build = int.Parse(versionParts[3]);

        switch (releaseType)
        {
            case "Major":
                major++;
                minor = 0;
                patch = 0;
                build = 0;
                break;
            case "Minor":
                minor++;
                patch = 0;
                build = 0;
                break;
            case "Patch":
                patch++;
                build = 0;
                break;
            case "Build":
                build++;
                break;
        }

        string newVersion = $"{major}.{minor}.{patch}.{build}";

        // Save the new version to a file
        File.WriteAllText(versionPath, newVersion);

        System.Diagnostics.Process.Start("git", "lfs pull");
        string buildPath = Path.Combine(Application.dataPath, "..", "Builds", $"ZombieSurvivalRPG_v{newVersion}");
    }
}