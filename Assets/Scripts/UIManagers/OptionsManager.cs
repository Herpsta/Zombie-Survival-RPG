using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OptionsManager : MonoBehaviour, IPanelManager
{
    // ... (rest of your variables)

    private List<IPanelManager> panelManagers = new List<IPanelManager>();

    public void RegisterPanel(IPanelManager panelManager)
    {
        if (panelManager != null)
        {
            panelManagers.Add(panelManager);
        }
        else
        {
            Debug.LogError("PanelManager is null");
        }
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
        HideAllPanels();

        // Set text descriptions with error checking
        SetDescriptionWithCheck(soundDescription, "Adjust the volume levels for music, SFX, and voice.");
        SetDescriptionWithCheck(graphicsDescription, "Change the resolution and quality settings.");
        SetDescriptionWithCheck(gameplayDescription, "Modify gameplay settings like difficulty.");
        SetDescriptionWithCheck(accessibilityDescription, "Customize settings for better accessibility.");

        // Add listener to apply button
        if (applyButton != null)
        {
            applyButton.onClick.AddListener(Save);
        }
        else
        {
            Debug.LogError("Apply button is null");
            return;
        }

        // TODO: Add calls to AddDropdownListener, AddSliderListener, and AddToggleListener here
    }

    // ... (rest of your methods)

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

    public void ShowAllPanels()
    {
        foreach (var panel in panelManagers)
        {
            panel.ShowPanel();
        }
    }

    public void HideAllPanels()
    {
        foreach (var panel in panelManagers)
        {
            panel.HidePanel();
        }
    }
}