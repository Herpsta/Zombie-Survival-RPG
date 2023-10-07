using System;
using System.Diagnostics;  // Add this line for Process
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildGame : EditorWindow
{
    string version = "default_version";

    [MenuItem("Build/Build All")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BuildGame));
    }

    void OnGUI()
    {
        GUILayout.Label("Enter the version number", EditorStyles.boldLabel);
        version = EditorGUILayout.TextField("Version", version);

        if (GUILayout.Button("Build"))
        {
            BuildAll();
        }
    }

    void BuildAll()
    {
        string buildPath = $"C:\\Users\\nyxar\\Zombie Survival RPG\\Builds\\ZombieSurvivalRPG_v{version}";

        // Create directory if it doesn't exist
        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }
        else
        {
            // Delete existing files
            DirectoryInfo di = new DirectoryInfo(buildPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SplashScreen.unity", "Assets/Scenes/TitleScreen.unity", "Assets/Scenes/OptionsScreen.unity" };
        buildPlayerOptions.locationPathName = $"{buildPath}/ZombieSurvivalRPG.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Run the batch file
        Process process = new Process();
        process.StartInfo.FileName = "BuildGame.bat";
        process.StartInfo.Arguments = version;  // Pass the version as an argument
        process.Start();
    }
}
