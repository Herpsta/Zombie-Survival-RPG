using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GraphicsOptionsManager : MonoBehaviour
{
    [Tooltip("Dropdown for resolution selection")]
    public TMP_Dropdown resolutionDropdown;

    [Tooltip("Dropdown for quality selection")]
    public TMP_Dropdown qualityDropdown;

    [Tooltip("Toggle for fullscreen mode")]
    public Toggle fullscreenToggle;

    [Tooltip("Dropdown for aspect ratio selection")]
    public TMP_Dropdown aspectRatioDropdown;

    private Resolution[] resolutions;
    public GameObject graphicsPanel;

    [SerializeField] private Settings settings; // Reference to the Settings class

    private void Start()
    {
        if (resolutionDropdown == null || qualityDropdown == null || fullscreenToggle == null ||
            aspectRatioDropdown == null)
        {
            Debug.LogError("All UI elements must be assigned in the inspector.");
            return;
        }

        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
        PopulateQualityDropdown();
        PopulateAspectRatioDropdown();

        resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });
        qualityDropdown.onValueChanged.AddListener(SetQuality);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        aspectRatioDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });

        // Start Load method as a separate task
        Load();
    }

    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void PopulateQualityDropdown()
    {
        qualityDropdown.ClearOptions();
        List<string> options = new List<string>(QualitySettings.names);
        qualityDropdown.AddOptions(options);
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }

    private void PopulateAspectRatioDropdown()
    {
        aspectRatioDropdown.ClearOptions();
        List<string> options = new List<string>() { "16:9", "16:10", "4:3" }; // Add more as needed
        aspectRatioDropdown.AddOptions(options);
        aspectRatioDropdown.value = 0; // Default to first option
        aspectRatioDropdown.RefreshShownValue();
    }

    private void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void ChangeResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public async Task Save()
    {
        try
        {
            Settings.GraphicsSettings graphicsSettings = new Settings.GraphicsSettings
            {
                resolutionIndex = resolutionDropdown.value,
                fullScreen = fullscreenToggle.isOn
            };

            await settings.SaveSettings();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save settings: " + e.Message);
        }

        // TODO: Save other settings
    }

    public async void Load()
    {
        try
        {
            // Load settings from the database
            await settings.Start();

            // Update UI on the main thread
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                GraphicsSettings graphicsSettings = settings.graphicsSettings;
                resolutionDropdown.value = graphicsSettings.resolutionIndex;
                fullscreenToggle.isOn = graphicsSettings.fullScreen;

                // TODO: Load other settings and update UI
            });
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load settings: " + e.Message);
        }
    }
}