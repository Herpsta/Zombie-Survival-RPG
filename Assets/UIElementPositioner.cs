using UnityEngine;
using UnityEngine.UI;

public class UIElementPositioner : MonoBehaviour
{
    public GameObject panel;  // The panel containing the UI elements
    public Button closeButton; // Close button
    public Button applyButton; // Apply button
    public Button backButton;  // Back button
    public Button defaultSettingsButton; // Default Settings button
    public Button[] otherButtons;  // The array of other buttons you want to position

    public float ySpacing = 40f; // Vertical spacing between buttons
    public float xSpacing = 40f; // Horizontal spacing between buttons

    void Start()
    {
        // Get the RectTransform of the panel
        RectTransform panelRect = panel.GetComponent<RectTransform>();

        // Position the Close button at the bottom center with padding
        PositionButton(closeButton, 0, -panelRect.rect.height / 2 + 50); // Added 50 units of padding

        // Position the Apply and Back buttons closer to the Close button
        PositionButton(applyButton, 150, -panelRect.rect.height / 2 + 300);  // 100 units above Close button
        PositionButton(backButton, -150, -panelRect.rect.height / 2 + 300);   // 100 units above Close button

        // Position the Default Settings button to the right, closer to the Close button
        PositionButton(defaultSettingsButton, panelRect.rect.width / 4, -panelRect.rect.height / 2 + 100);

        // Position the other buttons centered but a decent bit away from the Apply and Back buttons
        float startingYPos = 150;  // Starting y-position for the first other button
        for (int i = 0; i < otherButtons.Length; i++)
        {
            float yPos = startingYPos + (i * ySpacing);
            PositionButton(otherButtons[i], 0, yPos);
        }
    }

    void PositionButton(Button button, float xOffset, float yOffset)
    {
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        buttonRect.anchorMin = new Vector2(0.5f, 0.5f);
        buttonRect.anchorMax = new Vector2(0.5f, 0.5f);
        buttonRect.anchoredPosition = new Vector2(xOffset, yOffset);
    }
}
