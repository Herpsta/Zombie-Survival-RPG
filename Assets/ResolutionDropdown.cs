using System.Collections.Generic;
using UnityEngine;

public class ResolutionDropdown : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private HashSet<string> uniqueAspectRatios;

    void Start()
    {
        // Initialize the set to store unique aspect ratios
        uniqueAspectRatios = new HashSet<string>();

        // Get available screen resolutions
        resolutions = Screen.resolutions;

        // Clear the old options from the dropdown
        resolutionDropdown.ClearOptions();

        // Create a list to hold our new options
        List<string> options = new List<string>();

        // Loop through and set new options
        for (int i = 0; i < resolutions.Length; i++)
        {
            float aspectRatio = (float)resolutions[i].width / (float)resolutions[i].height;
            string aspectRatioStr = aspectRatio.ToString("0.00");

            // Only add resolutions with unique aspect ratios to dropdown
            if (!uniqueAspectRatios.Contains(aspectRatioStr))
            {
                string option = resolutions[i].width + " x " + resolutions[i].height + " (" + aspectRatioStr + ")";
                options.Add(option);
                uniqueAspectRatios.Add(aspectRatioStr);
            }
        }

        // Add new options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Listen for change events
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
    }

    public void OnResolutionChange()
    {
        // Get the index of the selected option
        int index = resolutionDropdown.value;

        // Find and set the corresponding resolution
        Resolution selectedResolution = resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}
