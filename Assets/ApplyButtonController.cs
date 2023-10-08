using UnityEngine;
using UnityEngine.UI;


public class ApplyButtonController : MonoBehaviour
{
    public Button applyButton;  // Reference to the Apply button
    private bool settingsChanged = false;  // Flag to track if settings have changed

    void Start()
    {
        // Initially set the Apply button to be non-interactable
        applyButton.interactable = false;
    }

    // Call this function whenever a setting changes
    public void OnSettingChanged()
    {
        settingsChanged = true;
        applyButton.interactable = true;  // Enable the Apply button
    }

    // Call this function when the Apply button is clicked
    public void OnApplyButtonClicked()
    {
        OptionsManager.Instance.ApplySettings();

        // Reset the flag and disable the Apply button
        settingsChanged = false;
        applyButton.interactable = false;
    }
}
