using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OptionsManager : Singleton<OptionsManager>
{
    public GameObject buttonContainer;
    public GameObject applyButton;

    public GameObject SoundPanel;
    public GameObject GraphicsPanel;
    public GameObject GameplayPanel;
    public GameObject AccessibilityPanel;

    public TMP_Text soundDescription;
    public TMP_Text graphicsDescription;
    public TMP_Text gameplayDescription;
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
    }

    private void SetDescriptionWithCheck(TMP_Text descriptionText, string description)
    {
        if (descriptionText != null)
        {
            descriptionText.text = description;
        }
        else
        {
            Debug.LogError("desriptionText is null");
        }
    }

    public void OnOptionsButtonClicked(IPanelManager panelManager)
    {
        ShowOnlyThisPanel(panelManager);
    }

    // New: Generic function to add dropdown listeners
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

    // New: Generic function to add slider listeners
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

    // New: Generic function to add toggle listeners
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