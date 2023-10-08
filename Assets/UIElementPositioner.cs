using UnityEngine;
using UnityEngine.UI;

public class UIElementPositioner : MonoBehaviour
{
    public GameObject panel;  // The panel containing the UI elements
    public Button[] buttons;  // The array of buttons you want to position

    public float xOffset = 20f;  // Horizontal offset from the left edge of the panel
    public float yOffset = 20f;  // Vertical offset from the bottom edge of the panel
    public float ySpacing = 40f; // Vertical spacing between buttons

    void Start()
    {
        // Get the RectTransform of the panel
        RectTransform panelRect = panel.GetComponent<RectTransform>();

        for (int i = 0; i < buttons.Length; i++)
        {
            // Get the RectTransform of each button
            RectTransform buttonRect = buttons[i].GetComponent<RectTransform>();

            // Set the anchor to bottom left
            buttonRect.anchorMin = new Vector2(0, 0);
            buttonRect.anchorMax = new Vector2(0, 0);

            // Calculate the y-position for each button
            float yPos = yOffset + (i * ySpacing);

            // Set the position relative to the panel
            buttonRect.anchoredPosition = new Vector2(xOffset, yPos);
        }
    }
}
