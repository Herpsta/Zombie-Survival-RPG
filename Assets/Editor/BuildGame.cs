using System;
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
        string versionPath = "Assets/version.txt"; // Replace with the actual path

        if (!File.Exists(versionPath))
        {
            Debug.LogError("version.txt file does not exist at the specified path: " + versionPath);
            return;
        }

        string currentVersion;
        try
        {
            currentVersion = File.ReadAllText(versionPath);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to read version.txt file: " + e.Message);
            return;
        }

        string[] versionParts = currentVersion.Split('.');
        if (versionParts.Length != 4)
        {
            Debug.LogError("Invalid version format in version.txt file");
            return;
        }

        int major, minor, patch, build;
        if (!int.TryParse(versionParts[0], out major) || !int.TryParse(versionParts[1], out minor) || !int.TryParse(versionParts[2], out patch) || !int.TryParse(versionParts[3], out build))
        {
            Debug.LogError("Invalid version format in version.txt file");
            return;
        }

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

        try
        {
            File.WriteAllText(versionPath, newVersion);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to write to version.txt file: " + e.Message);
            return;
        }

        // Define the build path and create it if it doesn't exist
        string buildPath = Path.Combine(Application.dataPath, "..", "Builds", $"ZombieSurvivalRPG_v{newVersion}");
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }

        // Define build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SplashScreen.unity", "Assets/Scenes/TitleScreen.unity", "Assets/Scenes/OptionsScreen.unity" };
        buildPlayerOptions.locationPathName = Path.Combine(buildPath, "ZombieSurvivalRPG.exe"); // Replace with your game's name
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        // Perform the build
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");

            // Run the batch file after the build succeeds
            try
            {
                System.Diagnostics.Process.Start("C:\\Users\\nyxar\\OneDrive\\Desktop\\Backup\\Zombie-Survival-RPG\\BuildGame.bat");
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to run batch file: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("Build failed: " + summary);
        }
    }
}