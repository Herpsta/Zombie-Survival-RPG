using UnityEngine;
using UnityEngine.UI;

public class ResizePanel : MonoBehaviour
{
    // Reference to the MasterCanvas
    public Canvas MasterCanvas;

    // Reference to the Panel Prefab
    public GameObject PanelTemplate;

    void Start()
    {
        // Create an instance of the panel prefab
        GameObject panelInstance = Instantiate(PanelTemplate, MasterCanvas.transform);

        // Get the RectTransform component of the panel instance
        RectTransform panelRect = panelInstance.GetComponent<RectTransform>();

        // Set the anchor points to stretch across the canvas
        panelRect.anchorMin = new Vector2(0, 0);
        panelRect.anchorMax = new Vector2(1, 1);

        // Set the size and position to zero to fully stretch it
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;
    }
}
