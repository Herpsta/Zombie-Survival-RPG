using UnityEngine;
using UnityEngine.UI;

public class PanelResizer : MonoBehaviour
{
    // Reference to the MasterCanvas
    public Canvas masterCanvas;

    // Reference to the Panels
    public GameObject[] panels;

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
            panelRect.offsetMin = Vector2.zero;
            panelRect.offsetMax = Vector2.zero;
        }
    }
}
