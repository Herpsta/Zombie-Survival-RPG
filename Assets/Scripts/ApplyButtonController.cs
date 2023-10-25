using UnityEngine;
using UnityEngine.UI; // Required for handling UI elements

public class ApplyButtonController : MonoBehaviour
{
    [Tooltip("The apply button")]
    public GameObject applyButton;  // Changed to GameObject

    [Tooltip("The error message text object")]
    public Text errorMessage;  // UI Text object to display error messages

    private bool settingsChanged = false;
    private Settings previousSettings; // Store the previous settings

    void Start()
    {
        // Disable the button at the start
        DisableButton();
        // Hide the error message at the start
        HideErrorMessage();
    }

    public void OnSettingChanged()
    {
        settingsChanged = true;
        // Enable the button when a setting is changed
        EnableButton();
    }

    public void OnApplyButtonClicked()
    {
        // Validate the new settings before applying them
        if (OptionsManager.Instance.Validate())
        {
            // Store the current settings before applying the new ones
            previousSettings = OptionsManager.Instance.GetCurrentSettings();

            OptionsManager.Instance.Save();
            settingsChanged = false;
            // Disable the button after applying settings
            DisableButton();
            // Hide any error message
            HideErrorMessage();
        }
        else
        {
            // Show an error message to the user
            ShowErrorMessage("Invalid settings. Please check and try again.");
            // Revert to previous settings if new settings are not validated
            RevertToPreviousSettings();
        }
    }

    public void OnCancelButtonClicked()
    {
        // Rollback to the previous settings if the cancel button is clicked
        if (previousSettings != null)
        {
            OptionsManager.Instance.Load(previousSettings);
        }
    }

    public void OnPreviewButtonClicked()
    {
        // Temporarily apply the settings for preview
        if (OptionsManager.Instance.Validate())
        {
            // Store the current settings before applying the new ones
            previousSettings = OptionsManager.Instance.GetCurrentSettings();

            OptionsManager.Instance.Save();
            // Hide any error message
            HideErrorMessage();
        }
        else
        {
            // Show an error message to the user
            ShowErrorMessage("Invalid settings. Please check and try again.");
            // Revert to previous settings if new settings are not validated
            RevertToPreviousSettings();
        }
    }

    private void DisableButton()
    {
        // Custom logic to disable the button
        // Using GameObject's SetActive method
        applyButton.SetActive(false);
    }

    private void EnableButton()
    {
        // Custom logic to enable the button
        // Using GameObject's SetActive method
        applyButton.SetActive(true);
    }

    private void ShowErrorMessage(string message)
    {
        // Show the error message
        errorMessage.text = message;
        errorMessage.gameObject.SetActive(true);
    }

    private void HideErrorMessage()
    {
        // Hide the error message
        errorMessage.gameObject.SetActive(false);
    }

    // TODO: Implement a method to revert to previous settings if new settings are not validated
    private void RevertToPreviousSettings()
    {
        if (previousSettings != null)
        {
            OptionsManager.Instance.Load(previousSettings);
        }
    }
}