using UnityEngine;

public class PanelResizer : MonoBehaviour
{
    // Reference to the MasterCanvas
    [Tooltip("Reference to the Master Canvas")]
    public Canvas masterCanvas;

    // Reference to the Panels
    [Tooltip("Array of panels to be resized")]
    public GameObject[] panels;

    // Padding for the panels
    [Tooltip("Padding for the panels")]
    public Vector2 padding;

    void Start()
    {
        // Get the RectTransform component of the MasterCanvas
        RectTransform canvasRect = masterCanvas.GetComponent<RectTransform>();

        foreach (GameObject panel in panels)
        {
            // Get the RectTransform component of each panel
            RectTransform panelRect = panel.GetComponent<RectTransform>();

            // Set the anchor points to stretch across the canvas
            panelRect.anchorMin = new Vector2(0, 0);
            panelRect.anchorMax = new Vector2(1, 1);

            // Set the size and position to zero to fully stretch it
            // Add padding to the panels
            panelRect.offsetMin = padding;
            panelRect.offsetMax = -padding;
        }
    }
}