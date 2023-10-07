using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class BuildGame
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[]
        {
            "Assets/Scenes/GameScene.unity",
            "Assets/Scenes/Old.unity",
            "Assets/Scenes/OptionsScreen.unity",
            "Assets/Scenes/PlayerInventoryScreen.unity",
            "Assets/Scenes/SplashScreen.unity",
            "Assets/Scenes/TitleScreen.unity"
        };
        buildPlayerOptions.locationPathName = "Builds/ZombieSurvivalRPG.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Start the batch file to prompt for version number
        Process process = new Process();
        process.StartInfo.FileName = "BuildGame.bat";
        process.Start();
    }
}
