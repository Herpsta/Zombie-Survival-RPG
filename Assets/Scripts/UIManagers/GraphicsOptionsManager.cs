using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public interface IGraphicsOptions
{
    Task SaveSettings();
    Task LoadSettings();
}

public class GraphicsOptionsManager : MonoBehaviour, IGraphicsOptions, IGraphicsSettings
{
    [Tooltip("Dropdown for resolution selection")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [Tooltip("Dropdown for quality selection")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Tooltip("Toggle for fullscreen mode")]
    [SerializeField] private Toggle fullscreenToggle;

    [Tooltip("Dropdown for aspect ratio selection")]
    [SerializeField] private TMP_Dropdown aspectRatioDropdown;

    private Resolution[] resolutions;
    public GameObject graphicsPanel;

    [SerializeField] private Settings settings; // Reference to the Settings class

    private CancellationTokenSource cts;

    private bool isDestroyed = false;

    private void Awake()
    {
        cts = new CancellationTokenSource();
    }

    private void Start()
    {
        if (resolutionDropdown == null || qualityDropdown == null || fullscreenToggle == null ||
            aspectRatioDropdown == null)
        {
            Debug.LogError("All UI elements must be assigned in the inspector.");
            enabled = false;  // Disable script if UI elements are null
            return;
        }

        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
        PopulateQualityDropdown();
        PopulateAspectRatioDropdown();
    
        resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(); });
        qualityDropdown.onValueChanged.AddListener(SetQuality);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        aspectRatioDropdown.onValueChanged.AddListener(delegate { UpdateResolutionsForAspectRatio(); });  // Updated this line

        // Start LoadSettings method as a separate task
        LoadSettings();
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
        List<string> options = new List<string>() { "16:9", "16:10", "4:3" };  // Add more as needed
        aspectRatioDropdown.AddOptions(options);
        aspectRatioDropdown.value = 0;  // Default to first option
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

    private void UpdateResolutionsForAspectRatio()
    {
        string[] aspectRatioParts = aspectRatioDropdown.options[aspectRatioDropdown.value].text.Split(':');
        float aspectRatio = float.Parse(aspectRatioParts[0]) / float.Parse(aspectRatioParts[1]);

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            float resolutionAspectRatio = (float)resolutions[i].width / resolutions[i].height;
            if (Mathf.Approximately(resolutionAspectRatio, aspectRatio))
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void ChangeResolution()
    {
        string[] resolutionParts = resolutionDropdown.options[resolutionDropdown.value].text.Split('x');
        int width = int.Parse(resolutionParts[0].Trim());
        int height = int.Parse(resolutionParts[1].Trim());
        Screen.SetResolution(width, height, Screen.fullScreen);
    }


    public int ResolutionIndex { get; set; }  // Implementation of IGraphicsSettings interface
    public bool FullScreen { get; set; }  // Implementation of IGraphicsSettings interface

    public async Task SaveSettings()
    {
        if (isDestroyed) return;  // Check if object is destroyed before proceeding

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
    }

    public async Task LoadSettings()
    {
        if (isDestroyed) return;  // Check if object is destroyed before proceeding

        try
        {
            // Load settings from the database
            await settings.Start();

            // Update UI on the main thread
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                Settings.GraphicsSettings graphicsSettings = settings.graphicsSettings;
                resolutionDropdown.value = graphicsSettings.resolutionIndex;
                fullscreenToggle.isOn = graphicsSettings.fullScreen;
            });
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load settings: " + e.Message);
        }
    }

    private void OnDestroy()
    {
        isDestroyed = true;
        cts.Cancel();
    }
}
