using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;

public class BuildGame
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        // Retrieve the version number from command-line arguments
        string[] commandLineArgs = System.Environment.GetCommandLineArgs();
        string version = "";

        for (int i = 0; i < commandLineArgs.Length; i++)
        {
            if (commandLineArgs[i] == "-executeMethod" && i + 2 < commandLineArgs.Length)
            {
                if (commandLineArgs[i + 1] == "BuildGame.BuildAll")
                {
                    version = commandLineArgs[i + 2];
                    break;
                }
            }
        }

        if (string.IsNullOrEmpty(version))
        {
            UnityEngine.Debug.LogError("Version number not provided. Build aborted.");
            return;
        }

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
        buildPlayerOptions.locationPathName = "Builds/ZombieSurvivalRPG_v" + version + ".exe";

        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);

        // Run the batch file
        Process process = new Process();
        process.StartInfo.FileName = "C:\\Users\\nyxar\\Zombie Survival RPG\\BuildGame.bat";
        process.Start();
    }
}
