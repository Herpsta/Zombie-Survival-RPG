using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Manages the Apply button in the settings menu.
/// Implements the IUIElement, IErrorHandle, and ISaveState interfaces.
/// </summary>
public class ApplyButtonController : MonoBehaviour, IUIElement, IErrorHandle, ISaveState
{
    [Tooltip("The apply button")]
    public GameObject applyButton;

    [Tooltip("The error message text object")]
    public Text errorMessage;

    private bool settingsChanged = false;
    private ISettings previousSettings;

    public static ApplyButtonController Instance { get; private set; }

    public static event Action OnSettingsChanged;

    private IOptionsManager optionsManager;
    private ISettings settings;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Dependency Injection (Assuming you have a method to get these instances)
        optionsManager = DependencyInjector.GetDependency<IOptionsManager>();
        settings = DependencyInjector.GetDependency<ISettings>();

        if (applyButton == null || errorMessage == null)
        {
            LogError("ApplyButton or ErrorMessage is not assigned in the inspector");
            this.enabled = false;
            return;
        }

        if (optionsManager == null || settings == null)
        {
            LogError("Dependencies are not properly set up");
            this.enabled = false;
            return;
        }

        Hide();
        HideErrorMessage();

        OnSettingsChanged += OnSettingChanged;
    }

    void Update()
    {
        if (settingsChanged)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void OnSettingChanged()
    {
        settingsChanged = true;
    }

    public void OnApplyButtonClicked()
    {
        if (optionsManager.Validate())
        {
            previousSettings = settings.GetCurrentSettings().Clone();
            SaveState();
            settingsChanged = false;
            Hide();
            HideErrorMessage();
        }
        else
        {
            ShowErrorMessage("Invalid settings. Please check and try again.");
            LoadState();
        }
    }

    public void OnCancelButtonClicked()
    {
        LoadState();
    }

    public void OnPreviewButtonClicked()
    {
        if (optionsManager.Validate())
        {
            previousSettings = settings.GetCurrentSettings().Clone();
            SaveState();
            HideErrorMessage();
            Invoke("LoadState", 5f);
        }
        else
        {
            ShowErrorMessage("Invalid settings. Please check and try again.");
            LoadState();
        }
    }

    public void Show()
    {
        applyButton.SetActive(true);
    }

    public void Hide()
    {
        applyButton.SetActive(false);
    }

    private void ShowErrorMessage(string message)
    {
        errorMessage.text = message;
        errorMessage.gameObject.SetActive(true);
    }

    private void HideErrorMessage()
    {
        errorMessage.gameObject.SetActive(false);
    }

    public void SaveState()
    {
        settings.SaveSettings();
    }

    public void LoadState()
    {
        if (previousSettings != null)
        {
            settings.Load(previousSettings);
        }
    }

    public void LogError(string message)
    {
        Debug.LogError(message);
    }

    public void HandleException(Exception ex)
    {
        Debug.LogException(ex);
    }

    private void OnDestroy()
    {
        OnSettingsChanged -= OnSettingChanged;
    }
}
