using UnityEngine;
using FMODUnity;

public class ApplyButtonController : MonoBehaviour
{
    public FMODUIButton applyButton;  // Changed to FMODUIButton
    private bool settingsChanged = false;

    void Start()
    {
        // Disable the button at the start
        DisableButton();
    }

    public void OnSettingChanged()
    {
        settingsChanged = true;
        // Enable the button when a setting is changed
        EnableButton();
    }

    public void OnApplyButtonClicked()
    {
        OptionsManager.Instance.Save();
        settingsChanged = false;
        // Disable the button after applying settings
        DisableButton();
    }

    private void DisableButton()
    {
        // Custom logic to disable the FMODUIButton
        // Using GameObject's SetActive method as a placeholder
        applyButton.gameObject.SetActive(false);
    }

    private void EnableButton()
    {
        // Custom logic to enable the FMODUIButton
        // Using GameObject's SetActive method as a placeholder
        applyButton.gameObject.SetActive(true);
    }
}
