using UnityEditor;
using System.Diagnostics;
using System;

public class BuildGame
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        string version = Environment.GetEnvironmentVariable("VERSION");
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[]
        {
            "Assets/Scenes/SplashScreen.unity",
            "Assets/Scenes/TitleScreen.unity",
            "Assets/Scenes/OptionsScreen.unity"
        };
        buildPlayerOptions.locationPathName = $"Builds/ZombieSurvivalRPG_v{version}.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        Process process = new Process();
        process.StartInfo.FileName = "BuildGame.bat";
        process.Start();
    }
}