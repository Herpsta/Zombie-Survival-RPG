using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Containers;
using System.Collections.Generic;
using UnityEngine;

public class DoozyUIManager : MonoBehaviour
{
    // Singleton instance
    public static DoozyUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to show a panel
    public void ShowPanel(string viewCategory, string viewName)
    {
        UIView.Show(viewCategory, viewName);  // show category - ANIMATED
    }

    // Method to show a panel instantly (without animation)
    public void ShowPanelInstant(string viewCategory, string viewName)
    {
        UIView.Show(viewCategory, viewName, true);  // show category - INSTANT
    }

    // Method to hide a panel
    public void HidePanel(string viewCategory, string viewName)
    {
        UIView.Hide(viewCategory, viewName);  // hide category - ANIMATED
    }

    // Method to hide a panel instantly (without animation)
    public void HidePanelInstant(string viewCategory, string viewName)
    {
        UIView.Hide(viewCategory, viewName, true);  // hide category - INSTANT
    }

    // Your custom code for saving and loading options
    public void SaveOptions()
    {
        // Your save logic here
    }

    public void LoadOptions()
    {
        // Your load logic here
    }
}
