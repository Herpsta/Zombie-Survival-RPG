using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown aspectRatioDropdown;

    void Start()
    {
        PopulateResolutions();
        PopulateAspectRatios();
    }

    void PopulateResolutions()
    {
        List<string> resolutions = new List<string>();
        foreach (Resolution resolution in Screen.resolutions)
        {
            string resolutionString = resolution.width + "x" + resolution.height;
            resolutions.Add(resolutionString);
        }
        resolutionDropdown.AddOptions(resolutions);

        // Debugging
        Debug.Log("Number of resolutions: " + Screen.resolutions.Length);
        Debug.Log("Dropdown options count: " + resolutionDropdown.options.Count);
    }


    void PopulateAspectRatios()
    {
        List<string> aspectRatios = new List<string> { "16:9", "16:10", "4:3", "32:9" };
        aspectRatioDropdown.AddOptions(aspectRatios);
    }

    public void OnResolutionChange(int index)
    {
        string[] dimensions = resolutionDropdown.options[index].text.Split('x');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void OnAspectRatioChange(int index)
    {
        float aspectRatio = 0f;
        switch (index)
        {
            case 0:
                aspectRatio = 16f / 9f;
                break;
            case 1:
                aspectRatio = 16f / 10f;
                break;
            case 2:
                aspectRatio = 4f / 3f;
                break;
            case 3:
                aspectRatio = 32f / 9f;
                break;
        }
        Camera.main.aspect = aspectRatio;
    }
}
