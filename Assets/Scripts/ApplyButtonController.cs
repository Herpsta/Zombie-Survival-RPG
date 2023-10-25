using UnityEngine;
using UnityEngine.UI;

public class ApplyButtonController : MonoBehaviour
{
    [Tooltip("The apply button")]
    public GameObject applyButton;

    [Tooltip("The error message text object")]
    public Text errorMessage;

    private bool settingsChanged = false;
    private Settings previousSettings;

    void Start()
    {
        if (applyButton == null || errorMessage == null)
        {
            Debug.LogError("ApplyButton or ErrorMessage is not assigned in the inspector");
            this.enabled = false; // Disable this script
            return;
        }

        if (OptionsManager.Instance == null)
        {
            Debug.LogError("OptionsManager instance is not properly set up");
            this.enabled = false; // Disable this script
            return;
        }

        DisableButton();
        HideErrorMessage();
    }

    void Update()
    {
        if (settingsChanged)
        {
            EnableButton();
        }
        else
        {
            DisableButton();
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
            OptionsManager.Instance.Save();
            settingsChanged = false;
            DisableButton();
            HideErrorMessage();
        }
        else
        {
            ShowErrorMessage("Invalid settings. Please check and try again.");
            RevertToPreviousSettings();
        }
    }

    public void OnCancelButtonClicked()
    {
        RevertToPreviousSettings();
    }

    public void OnPreviewButtonClicked()
    {
        if (OptionsManager.Instance.Validate())
        {
            previousSettings = OptionsManager.Instance.GetCurrentSettings().Clone();
            OptionsManager.Instance.Save();
            HideErrorMessage();
            // Delay the revert to allow for preview
            Invoke("RevertToPreviousSettings", 5f); // Revert after 5 seconds
        }
        else
        {
            ShowErrorMessage("Invalid settings. Please check and try again.");
            RevertToPreviousSettings();
        }
    }

    private void DisableButton()
    {
        applyButton.SetActive(false);
    }

    private void EnableButton()
    {
        applyButton.SetActive(true);
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

    private void RevertToPreviousSettings()
    {
        if (previousSettings != null)
        {
            OptionsManager.Instance.Load(previousSettings);
        }
    }
}