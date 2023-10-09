using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        Debug.Log("Is resolutionDropdown null? " + (resolutionDropdown == null));

        resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        foreach (Resolution res in resolutions)
        {
            string option = res.width + " x " + res.height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }
}
