using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OptionsManager : IPanelManager
{
    [Tooltip("Container for buttons")]
    public GameObject buttonContainer;
    [Tooltip("Apply button")]
    public GameObject applyButton;

    [Tooltip("Sound settings panel")]
    public GameObject SoundPanel;
    [Tooltip("Graphics settings panel")]
    public GameObject GraphicsPanel;
    [Tooltip("Gameplay settings panel")]
    public GameObject GameplayPanel;
    [Tooltip("Accessibility settings panel")]
    public GameObject AccessibilityPanel;

    [Tooltip("Sound settings description")]
    public TMP_Text soundDescription;
    [Tooltip("Graphics settings description")]
    public TMP_Text graphicsDescription;
    [Tooltip("Gameplay settings description")]
    public TMP_Text gameplayDescription;
    [Tooltip("Accessibility settings description")]
    public TMP_Text accessibilityDescription;

    private List<IPanelManager> panelManagers = new List<IPanelManager>();

    public void RegisterPanel(IPanelManager panelManager)
    {
        panelManagers.Add(panelManager);
    }

    public void ShowOnlyThisPanel(IPanelManager activePanel)
    {
        foreach (var panel in panelManagers)
        {
            if (panel == activePanel)
            {
                panel.ShowPanel();
            }
            else
            {
                panel.HidePanel();
            }
        }
    }

    private void Start()
    {
        // Load saved options
        Load();

        // Initialize panels as inactive
        SoundPanel.SetActive(false);
        GraphicsPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        AccessibilityPanel.SetActive(false);

        // Set text descriptions with error checking
        SetDescriptionWithCheck(soundDescription, "Adjust the volume levels for music, SFX, and voice.");
        SetDescriptionWithCheck(graphicsDescription, "Change the resolution and quality settings.");
        SetDescriptionWithCheck(gameplayDescription, "Modify gameplay settings like difficulty.");
        SetDescriptionWithCheck(accessibilityDescription, "Customize settings for better accessibility.");

        // TODO: Add calls to AddDropdownListener, AddSliderListener, and AddToggleListener here
    }

    private void SetDescriptionWithCheck(TMP_Text descriptionText, string description)
    {
        if (descriptionText != null)
        {
            descriptionText.text = description;
        }
        else
        {
            Debug.LogError("descriptionText is null");
        }
    }

    public void OnOptionsButtonClicked(IPanelManager panelManager)
    {
        ShowOnlyThisPanel(panelManager);
    }

    private void AddDropdownListener(TMP_Dropdown dropdown, UnityAction<int> action, string errorMessage)
    {
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    private void AddSliderListener(Slider slider, UnityAction<float> action, string errorMessage)
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    private void AddToggleListener(Toggle toggle, UnityAction<bool> action, string errorMessage)
    {
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(action);
        }
        else
        {
            Debug.LogError(errorMessage);
        }
    }

    public void Save()
    {
        if (panelManagers != null)
            foreach (var panel in panelManagers)
            {
                panel.Save();
            }
    }

    public void Load()
    {
        foreach (var panel in panelManagers)
        {
            panel.Load();
        }
    }
}