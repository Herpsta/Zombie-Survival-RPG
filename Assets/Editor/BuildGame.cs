using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildGame
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        string version = Environment.GetEnvironmentVariable("VERSION");
        if (string.IsNullOrEmpty(version))
        {
            version = "default_version"; // Replace with your default versioning scheme
        }

        string buildPath = $"Builds/ZombieSurvivalRPG_v{version}";

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
        // Optionally, you can add code here to handle the build report
    }
}
