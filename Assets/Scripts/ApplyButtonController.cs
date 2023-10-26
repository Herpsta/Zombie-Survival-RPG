using UnityEngine;
using UnityEngine.UI;
using System;

public class ApplyButtonController : MonoBehaviour, IUIElement, IErrorHandle, ISaveState
{
    [Tooltip("The apply button")]
    public GameObject applyButton;

    [Tooltip("The error message text object")]
    public Text errorMessage;

    private bool settingsChanged = false;
    private Settings previousSettings;

    // Singleton instance
    public static ApplyButtonController Instance { get; private set; }

    // Event for settings change
    public static event Action OnSettingsChanged;

    private void Awake()
    {
        // Singleton pattern
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
        if (applyButton == null || errorMessage == null)
        {
            LogError("ApplyButton or ErrorMessage is not assigned in the inspector");
            this.enabled = false; // Disable this script
            return;
        }

        if (OptionsManager.Instance == null)
        {
            LogError("OptionsManager instance is not properly set up");
            this.enabled = false; // Disable this script
            return;
        }

        Hide();
        HideErrorMessage();

        // Subscribe to event
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
        if (OptionsManager.Instance.Validate())
        {
            previousSettings = OptionsManager.Instance.GetCurrentSettings().Clone();
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
        if (OptionsManager.Instance.Validate())
        {
            previousSettings = OptionsManager.Instance.GetCurrentSettings().Clone();
            SaveState();
            HideErrorMessage();
            // Delay the revert to allow for preview
            Invoke("LoadState", 5f); // Revert after 5 seconds
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
        OptionsManager.Instance.Save();
    }

    public void LoadState()
    {
        if (previousSettings != null)
        {
            OptionsManager.Instance.Load(previousSettings);
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
        // Unsubscribe from event
        OnSettingsChanged -= OnSettingChanged;
    }
}