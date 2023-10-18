using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    // Dictionary to hold references to your panels
    public Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
    public GameObject[] panelObjects;

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
    public void ShowPanel(string panelName)
    {
        if (panels.ContainsKey(panelName))
        {
            panels[panelName].SetActive(true);
        }
    }

    // Method to hide a panel
    public void HidePanel(string panelName)
    {
        if (panels.ContainsKey(panelName))
        {
            panels[panelName].SetActive(false);
        }
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
